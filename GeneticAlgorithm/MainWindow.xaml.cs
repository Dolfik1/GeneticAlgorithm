using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneticAlgorithm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CultureInfo ci;
        public Random rnd = new Random();

        public int popsize, maxiter, tsize, itercount = 0;
        public double elitrate, mutrate;
        public string target;

        public MainWindow()
        {
            InitializeComponent();
            ci = new CultureInfo("en-US");//CultureInfo.CurrentUICulture.Name);
            tbMutation.Text = (Int32.MaxValue * double.Parse(tbMutationRate.Text, ci)).ToString();
        }

        public Task curTask;
        public CancellationTokenSource cts;
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (curTask == null || curTask.IsCanceled || curTask.IsCompleted || curTask.IsFaulted)
            {
                tbElitRate.IsEnabled = false;
                tbGeneticText.IsEnabled = false;
                tbMaxInterations.IsEnabled = false;
                tbMutation.IsEnabled = false;
                tbMutationRate.IsEnabled = false;
                tbPopSize.IsEnabled = false;
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;

                cts = new CancellationTokenSource();
                itercount = 0;
                tbMutation.Text = (Int32.MaxValue * double.Parse(tbMutationRate.Text, ci)).ToString();
                popsize = Int32.Parse(tbPopSize.Text);
                maxiter = Int32.Parse(tbMaxInterations.Text);
                target = tbGeneticText.Text;
                tsize = target.Length;
                mutrate = double.Parse(tbMutation.Text, ci);

                elitrate = double.Parse(tbElitRate.Text, ci);
                curTask = Task.Run(() => startGeneration(cts.Token), cts.Token);
            }
        }
        private void startGeneration(CancellationToken ct)
        {
            ga_struct[] pop_alpha = new ga_struct[popsize], pop_beta = new ga_struct[popsize];
            ga_struct[] population = new ga_struct[popsize], buffer = new ga_struct[popsize];

            init_population(ref pop_alpha, ref pop_beta);
            population = pop_alpha;
            buffer = pop_beta;

            for (int i = 0; i < maxiter; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        tbMainText.AppendText("Задача остановлена!\r\n");
                    }));
                    break;
                }

                calc_fitness(ref population);

                population = population.OrderBy(x => x.fitness).ToArray();

                print_best(population);

                if (population[0].fitness == 0)
                {
                    Dispatcher.Invoke(new Action(() => //Не самая лучшая идея
                    {
                        tbElitRate.IsEnabled = true;
                        tbGeneticText.IsEnabled = true;
                        tbMaxInterations.IsEnabled = true;
                        tbMutation.IsEnabled = true;
                        tbMutationRate.IsEnabled = true;
                        tbPopSize.IsEnabled = true;
                        btnStart.IsEnabled = true;
                        btnStop.IsEnabled = false;
                    }));
                    break;
                }
                mate(ref population, ref buffer);
                swap(ref population, ref buffer);
            }
        }
        private void init_population(ref ga_struct[] ga_list, ref ga_struct[] buffer)
        {
            ga_list = new ga_struct[popsize];

            for (int i = 0; i < popsize; i++)
            {
                ga_struct citizen = new ga_struct();

                citizen.fitness = 0;
                citizen.str = "";

                for (int j = 0; j < tsize; j++)
                {
                    citizen.str += (char)rnd.Next(0, 0x052f);//1279 - Кириллица
                }
                ga_list[i] = citizen;
            }
            buffer = new ga_struct[popsize];
            for (int i = 0; i < popsize; i++)
            {
                buffer[i] = new ga_struct();
            }
        }

        private void calc_fitness(ref ga_struct[] population)
        {
            int result;
            int tsize = target.Length;
            int fitness = 0;

            for (int i = 0; i < popsize; i++)
            {
                fitness = 0;
                for (int j = 0; j < tsize; j++)
                {
                    result = (int)((char)population[i].str[j]) - (int)((char)target[j]);
                    fitness += Math.Abs(result);
                }
                population[i].fitness = (uint)fitness;
            }
        }

        private void elitism(ref ga_struct[] population, ref ga_struct[] buffer, int esize)
        {
            for (int i = 0; i < esize; i++)
            {
                buffer[i].str = population[i].str;
                buffer[i].fitness = population[i].fitness;
            }
        }

        private void mutate(ga_struct member)
        {
            int ipos = rnd.Next(0, tsize);
            int delta = rnd.Next(0, 0x052f);//89 + 32);

            //member.str[ipos] = (char)((member.str[ipos] + delta) % 122);
            char[] arr = member.str.ToArray();
            arr[ipos] = (char)((arr[ipos] + delta) % 0x052f);
            member.str = new string (arr);
        }

        private void mate(ref ga_struct[] population, ref ga_struct[] buffer)
        {
            
            int esize = (int)(popsize * elitrate);
            int spos, i1, i2;

            elitism(ref population, ref buffer, esize);

           
            for (int i = esize; i < popsize; i++)
            {
                i1 = rnd.Next(0, popsize / 2);
                i2 = rnd.Next(0, popsize / 2);

                spos = rnd.Next(0, tsize);
                buffer[i].str = population[i1].str.Substring(0, spos) + population[i2].str.Substring(spos);//, esize - spos);

                if (rnd.Next() < mutrate)
                    mutate(buffer[i]);
            }
        }

        void print_best(ga_struct[] gav)
        {
            Dispatcher.Invoke(new Action(() => 
            {
                tbMainText.ScrollToEnd();
                itercount++;
                tbMainText.AppendText("(" + itercount + ") " + "Лучшее: " + gav[0].str + " (" + gav[0].fitness + ")" + "\r\n"); 
            }));   
        }

        void swap(ref ga_struct[] population, ref ga_struct[] buffer)
        {
            ga_struct[] temp = population;
            population = buffer;
            buffer = temp;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (curTask != null && !curTask.IsCanceled || !curTask.IsCompleted || !curTask.IsFaulted)
            {
                cts.Cancel();
                tbElitRate.IsEnabled = true;
                tbGeneticText.IsEnabled = true;
                tbMaxInterations.IsEnabled = true;
                tbMutation.IsEnabled = true;
                tbMutationRate.IsEnabled = true;
                tbPopSize.IsEnabled = true;
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
            }
        }
    }

    public class ga_struct
    {
        public string str;
        public uint fitness;
    };
}
