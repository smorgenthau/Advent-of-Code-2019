using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var d1P1 = Day1Puzzle1();
            var d1P2 = Day1Puzzle2();
            Console.WriteLine($"Day 1 - Puzzle 1: {d1P1} Puzzle 2: {d1P2}");

            var d2P1 = Day2Puzzle1();
            var d2P2 = Day2Puzzle2();
            Console.WriteLine($"Day 2 - Puzzle 1: {d2P1} Puzzle 2: {d2P2}");

            var d3P1 = Day3Puzzle1();
            var d3P2 = Day3Puzzle2();
            Console.WriteLine($"Day 3 - Puzzle 1: {d3P1} Puzzle 2: {d3P2}");

            var d4P1 = Day4Puzzle1();
            var d4P2 = Day4Puzzle2();
            Console.WriteLine($"Day 4 - Puzzle 1: {d4P1} Puzzle 2: {d4P2}");

            var d5P1 = Day5Puzzle1();
            var d5P2 = Day5Puzzle2();
            Console.WriteLine($"Day 5 - Puzzle 1: {d5P1} Puzzle 2: {d5P2}");


            var d6P1 = Day6Puzzle1();
            var d6P2 = Day6Puzzle2();
            Console.WriteLine($"Day 6 - Puzzle 1: {d6P1} Puzzle 2: {d6P2}");

            var d7P1 = Day7Puzzle1();
            var d7P2 = Day7Puzzle2();
            Console.WriteLine($"Day 7 - Puzzle 1: {d7P1} Puzzle 2: {d7P2}");

            var d8P1 = Day8Puzzle1();
            Console.WriteLine($"Day 8 - Puzzle 1: {d8P1}");
            Console.WriteLine("Puzzle 2:");
            Day8Puzzle2();

            var d9P1 = Day9Puzzle1();
            var d9P2 = Day9Puzzle2();
            Console.WriteLine($"Day 9 - Puzzle 1: {d9P1} Puzzle 2: {d9P2}");

            var d10P1 = Day10Puzzle1();
            var d10P2 = Day10Puzzle2();
            Console.WriteLine($"Day 10 - Puzzle 1: {d10P1} Puzzle 2: {d10P2}");

            var d11P1 = Day11Puzzle1();
            Console.WriteLine($"Day 11 - Puzzle 1: {d11P1}");
            Console.WriteLine("Puzzle 2:"); 
            Day11Puzzle2();

            var d12P1 = Day12Puzzle1();
            var d12P2 = Day12Puzzle2();
            Console.WriteLine($"Day 12 - Puzzle 1: {d12P1} Puzzle 2: {d12P2}");

            var d13P1 = Day13Puzzle1();
            var d13P2 = Day13Puzzle2();
            Console.WriteLine($"Day 13 - Puzzle 1: {d13P1} Puzzle 2: {d13P2}");

            var d14P1 = Day14Puzzle1();
            var d14P2 = Day14Puzzle2();
            Console.WriteLine($"Day 13 - Puzzle 1: {d14P1} Puzzle 2: {d14P2}");

            //var d10P1 = Day10Puzzle1();
            //var d10P2 = Day10Puzzle2();
            //Console.WriteLine($"Day 10 - Puzzle 1: {d10P1} Puzzle 2: {d10P2}");

            Console.Write("Finished Puzzles, Press Enter to exit");
            Console.Read();
        }

        static int Day1Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day01.txt");
            string fileText = file.ReadToEnd();
            var fuelList = fileText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => int.Parse(f)).ToList();

            int returner = 0;
            foreach (var item in fuelList)
            {
                var toAdd = (item / 3) - 2;
                returner += toAdd;
            }
            return returner;

        }
        static int Day1Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day01.txt");
            string fileText = file.ReadToEnd();
            var fuelList = fileText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => int.Parse(f)).ToList();

            int returner = 0;
            foreach (var item in fuelList)
            {
                var initial = (item / 3) - 2;
                var toAdd = 0;
                while (initial > 0)
                {
                    toAdd += initial;
                    initial = initial / 3 - 2;
                }
                returner += toAdd;
            }
            return returner;

        }

        static long Day2Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day02.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();           

            seed[1] = 12;
            seed[2] = 2;

            Compiler compiler = new Compiler(seed);
            compiler.Compile();

            return seed[0];
        }
        static int Day2Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day02.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            for (int first = 0; first < 100; first++)
            {
                for (int second = 0; second < 100; second++)
                {
                    var seedCopy = new List<long>(seed);
                    seedCopy[1] = first;
                    seedCopy[2] = second;

                    Compiler compiler = new Compiler(seedCopy);
                    compiler.Compile();

                    if (seedCopy[0] == 19690720)
                    {
                        return first * 100 + second;
                    }
                }
            }

            return 0;
        }

        static int Day3Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day03.txt");
            string fileText = file.ReadToEnd();
            var seeds = fileText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var seed1 = seeds[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var seed2 = seeds[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var path1 = new List<Tuple<int, int>>();
            var path2 = new List<Tuple<int, int>>();

            path1.Add(Tuple.Create(0, 0));
            path2.Add(Tuple.Create(0, 0));

            foreach (var step in seed1)
            {
                char direction = step[0];
                int distance = Convert.ToInt32(step.Substring(1));
                int xChange = 0;
                int yChange = 0;
                switch (direction)
                {
                    case 'U':
                        yChange = 1;
                        break;
                    case 'D':
                        yChange = -1;
                        break;
                    case 'R':
                        xChange = 1;
                        break;
                    case 'L':
                        xChange = -1;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < distance; i++)
                {
                    var oldStep = path1.Last();
                    var newStep = Tuple.Create(oldStep.Item1 + xChange, oldStep.Item2 + yChange);
                    path1.Add(newStep);
                }
            }

            foreach (var step in seed2)
            {
                char direction = step[0];
                int distance = Convert.ToInt32(step.Substring(1));
                int xChange = 0;
                int yChange = 0;
                switch (direction)
                {
                    case 'U':
                        yChange = 1;
                        break;
                    case 'D':
                        yChange = -1;
                        break;
                    case 'R':
                        xChange = 1;
                        break;
                    case 'L':
                        xChange = -1;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < distance; i++)
                {
                    var oldStep = path2.Last();
                    var newStep = Tuple.Create(oldStep.Item1 + xChange, oldStep.Item2 + yChange);
                    path2.Add(newStep);
                }
            }


            var crosses = path1.Intersect(path2);
            var distances = new List<int>();
            foreach (var cross in crosses)
            {
                var distance = Math.Abs(cross.Item1) + Math.Abs(cross.Item2);
                if (distance != 0)
                    distances.Add(distance);
            }


            return distances.Min();
        }
        static int Day3Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day03.txt");
            string fileText = file.ReadToEnd();
            var seeds = fileText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var seed1 = seeds[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var seed2 = seeds[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var path1 = new List<Tuple<int, int>>();
            var path2 = new List<Tuple<int, int>>();

            path1.Add(Tuple.Create(0, 0));
            path2.Add(Tuple.Create(0, 0));

            foreach (var step in seed1)
            {
                char direction = step[0];
                int distance = Convert.ToInt32(step.Substring(1));
                int xChange = 0;
                int yChange = 0;
                switch (direction)
                {
                    case 'U':
                        yChange = 1;
                        break;
                    case 'D':
                        yChange = -1;
                        break;
                    case 'R':
                        xChange = 1;
                        break;
                    case 'L':
                        xChange = -1;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < distance; i++)
                {
                    var oldStep = path1.Last();
                    var newStep = Tuple.Create(oldStep.Item1 + xChange, oldStep.Item2 + yChange);
                    path1.Add(newStep);
                }
            }

            foreach (var step in seed2)
            {
                char direction = step[0];
                int distance = Convert.ToInt32(step.Substring(1));
                int xChange = 0;
                int yChange = 0;
                switch (direction)
                {
                    case 'U':
                        yChange = 1;
                        break;
                    case 'D':
                        yChange = -1;
                        break;
                    case 'R':
                        xChange = 1;
                        break;
                    case 'L':
                        xChange = -1;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < distance; i++)
                {
                    var oldStep = path2.Last();
                    var newStep = Tuple.Create(oldStep.Item1 + xChange, oldStep.Item2 + yChange);
                    path2.Add(newStep);
                }
            }


            var crosses = path1.Intersect(path2);
            var distances = new List<int>();
            foreach (var cross in crosses)
            {
                var items1 = path1.FindIndex(p => p.Item1 == cross.Item1 && p.Item2 == cross.Item2);
                var items2 = path2.FindIndex(p => p.Item1 == cross.Item1 && p.Item2 == cross.Item2);



                var distance = items1 + items2;
                if (distance != 0)
                    distances.Add(distance);
            }


            return distances.Min();
        }

        static int Day4Puzzle1()
        {
            var password = "359282";

            int validPasswords = 0;
            while (password != "820401")
            {
                if (Valid(password))
                {
                    validPasswords += 1;
                }

                password = (Convert.ToInt32(password) + 1).ToString("000000");
            }


            return validPasswords;
        }
        static bool Valid(string password)
        {
            bool hasDouble = false;
            bool isIncreasing = true;

            var pass = password.ToArray();
            for (int i = 1; i < password.Length; i++)
            {
                if (pass[i] < pass[i - 1])
                    isIncreasing = false;
                if (pass[i] == pass[i - 1])
                    hasDouble = true;
            }
            return hasDouble && isIncreasing;
        }
        static int Day4Puzzle2()
        {
            var password = "359282";
            int validPasswords = 0;
            while (password != "820401")
            {
                if (Valid2(password))
                    validPasswords += 1;
                password = (Convert.ToInt32(password) + 1).ToString("000000");
            }
            return validPasswords;
        }
        static bool Valid2(string password)
        {
            bool hasDouble = false;
            bool hasExactDouble = false;
            bool isIncreasing = true;

            string subPassword = "";
            for (int i = 1; i < password.Length; i++)
            {
                if (password[i] < password[i - 1])
                    isIncreasing = false;
                if (password[i] == password[i - 1])
                {
                    hasDouble = true;
                    subPassword += password[i];
                }
            }

            for (int i = 0; i < subPassword.Length; i++)
            {
                if ((i == 0 || subPassword[i] != subPassword[i - 1]) && (i == subPassword.Length - 1 || subPassword[i] != subPassword[i + 1]))
                    hasExactDouble = true;
            }

            return hasDouble && hasExactDouble && isIncreasing;
        }


        static long Day5Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day05.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            Compiler compiler = new Compiler(seed);
            compiler.AddInputs(1);
            var output = compiler.Compile();

            return output.Last();
        }
        static long Day5Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day05.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            Compiler compiler = new Compiler(seed);
            compiler.AddInputs(5);
            var output = compiler.Compile();

            return output.Last();
        }


        static int Day6Puzzle1()
        {
            var seed = new List<string>();
            string line = "";
            var file = new StreamReader(@"..\..\Data\Day06.txt");

            Dictionary<string, string> orbitList = new Dictionary<string, string>();
            while ((line = file.ReadLine()) != null)
            {
                var pair = line.Split(')');
                orbitList.Add(pair[1], pair[0]);
            }

            int totalOrbits = 0;
            foreach (var item in orbitList)
            {
                int orbits = 1;
                var newItem = item.Value;
                while (newItem != "COM")
                {
                    newItem = orbitList[newItem];
                    orbits += 1;
                }

                totalOrbits += orbits;
            }

            return totalOrbits;
        }
        static int Day6Puzzle2()
        {
            var seed = new List<string>();
            string line = "";
            var file = new StreamReader(@"..\..\Data\Day06.txt");

            Dictionary<string, string> orbitList = new Dictionary<string, string>();
            Dictionary<string, List<string>> orbitRelations = new Dictionary<string, List<string>>();
            while ((line = file.ReadLine()) != null)
            {
                var pair = line.Split(')');
                orbitList.Add(pair[1], pair[0]);

                if (orbitRelations.ContainsKey(pair[0]))
                    orbitRelations[pair[0]].Add(pair[1]);
                else
                    orbitRelations.Add(pair[0], new List<string> { pair[1] });

                if (orbitRelations.ContainsKey(pair[1]))
                    orbitRelations[pair[1]].Add(pair[0]);
                else
                    orbitRelations.Add(pair[1], new List<string> { pair[0] });

            }

            //var starter = orbitRelations["YOU"];

            List<string> test = new List<string>();
            //foreach(var obj in starter)
            //{
            var curPath = new List<string> { "YOU" };
            test = DFS(orbitRelations, curPath.ToArray(), "YOU");
            var forbiddenWords = new List<string> { "YOU", "SAN" };
            var test2 = test.Except(forbiddenWords);
            //}

            return test2.Count() - 1;
        } //Need to improve
        static List<string> DFS(Dictionary<string, List<string>> tree, string[] curPath, string curObj)
        {
            if (curObj == "SAN")
            {
                var temp = curPath.ToList();
                temp.Add(curObj);
                return temp;
            }

            var valids = new List<List<string>>();
            var starter = tree[curObj];
            foreach (var obj in starter)
            {
                if (!curPath.Contains(obj))
                {
                    var temp = curPath.ToList();
                    temp.Add(obj);
                    var copyPath = temp.ToArray();
                    var test = DFS(tree, copyPath, obj);

                    if (test != null && test.LastOrDefault() == "SAN")
                        valids.Add(test);
                }
            }

            return valids.OrderBy(v => v.Count()).FirstOrDefault();
        }


        static long Day7Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day07.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList(); 

            Dictionary<string, long> tests = new Dictionary<string, long>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        for (int l = 0; l < 5; l++)
                        {
                            for (int m = 0; m < 5; m++)
                            {
                                var order = new List<int> { i, j, k, l, m };
                                if (order.Distinct().Count() == 5)
                                {
                                    var seedCopy1 = new List<long>(seed);
                                    var seedCopy2 = new List<long>(seed);
                                    var seedCopy3 = new List<long>(seed);
                                    var seedCopy4 = new List<long>(seed);
                                    var seedCopy5 = new List<long>(seed);

                                    var first = new Compiler(seedCopy1, order[0], 0);
                                    var firstResult = first.Compile();

                                    var second = new Compiler(seedCopy2, order[1], firstResult.Last());
                                    var secondResult = second.Compile();
                                    
                                    var third = new Compiler(seedCopy3, order[2], secondResult.Last());
                                    var thirdResult = third.Compile();
                                    
                                    var fourth = new Compiler(seedCopy4, order[3], thirdResult.Last());
                                    var fourthResult = fourth.Compile();
                                    
                                    var fifth = new Compiler(seedCopy5, order[4], fourthResult.Last());
                                    var fifthResult = fifth.Compile();

                                    string key = $"{order[0]}{order[1]}{order[2]}{order[3]}{order[4]}";
                                    tests.Add(key, fifthResult.Last());
                                }
                            }

                        }

                    }

                }
            }

            var returner = tests.OrderBy(t => t.Value).Last().Value;
            return returner;
        }
        static long Day7Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day07.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList(); 
            
            Dictionary<string, long> tests = new Dictionary<string, long>();
            for (int i = 5; i < 10; i++)
            {
                for (int j = 5; j < 10; j++)
                {
                    for (int k = 5; k < 10; k++)
                    {
                        for (int l = 5; l < 10; l++)
                        {
                            for (int m = 5; m < 10; m++)
                            {
                                var order = new List<int> { i, j, k, l, m };
                                if (order.Distinct().Count() == 5)
                                {
                                    var seedCopy1 = new List<long>(seed);
                                    var seedCopy2 = new List<long>(seed);
                                    var seedCopy3 = new List<long>(seed);
                                    var seedCopy4 = new List<long>(seed);
                                    var seedCopy5 = new List<long>(seed);

                                    var first = new Compiler(seedCopy1, order[0], 0);
                                    var second = new Compiler(seedCopy2, order[1]);
                                    var third = new Compiler(seedCopy3, order[2]);
                                    var fourth = new Compiler(seedCopy4, order[3]);
                                    var fifth = new Compiler(seedCopy5, order[4]);

                                    List<long> finalResult = new List<long>();
                                    while (!fifth.HasTerminated)
                                    {
                                        var firstResult = first.Compile();
                                        second.AddInputs(firstResult.ToArray());
                                        var secondResult = second.Compile();
                                        third.AddInputs(secondResult.ToArray());
                                        var thirdResult = third.Compile();
                                        fourth.AddInputs(thirdResult.ToArray());
                                        var fourthResult = fourth.Compile();
                                        fifth.AddInputs(fourthResult.ToArray());
                                        var fifthResult = fifth.Compile();
                                        first.AddInputs(fifthResult.ToArray());


                                        finalResult = fifthResult;
                                    }

                                    string key = $"{order[0]}{order[1]}{order[2]}{order[3]}{order[4]}";
                                    tests.Add(key, finalResult.Last());
                                }
                            }

                        }

                    }

                }
            }

            var returner = tests.OrderBy(t => t.Value).Last().Value;
            return returner;
        } //Need to finish


        static int Day8Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day08.txt");
            string seed = file.ReadToEnd();
            var imageSlices = new List<string>();

            while (seed.Any())
            {
                var slice = seed.Substring(0, 150);
                seed = new string(seed.Skip(150).ToArray());//.ToString();
                imageSlices.Add(slice);
            }

            var least0s = imageSlices.OrderBy(t => t.Count(t2 => t2 == '0')).First();
            var oneCount = least0s.Count(t => t == '1');
            var twoCount = least0s.Count(t => t == '2');

            var returner = oneCount * twoCount;
            return returner;
        }
        static void Day8Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day08.txt");
            string seed = file.ReadToEnd();
            var imageSlices = new List<string>();

            while (seed.Any())
            {
                var slice = seed.Substring(0, 150);
                seed = new string(seed.Skip(150).ToArray());//.ToString();
                imageSlices.Add(slice);
            }

            var image = new string('2', 150).ToArray();

            foreach (var slice in imageSlices)
            {
                for (int i = 0; i < 150; i++)
                {
                    if (image[i] == '2')
                        image[i] = slice[i];
                }
            }

            var imageString = new string(image);
            while (imageString.Any())
            {
                var slice = imageString.Substring(0, 25);
                imageString = new string(imageString.Skip(25).ToArray());//.ToString();

                //slice = slice.Replace('1', ' ').Replace('0', '■');
                slice = slice.Replace('0', ' ').Replace('1', '■'); //Console is white-on-black, not black-on-white
                Console.WriteLine(slice);
            }
        }

        static long Day9Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day09.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            Compiler compiler = new Compiler(seed, 1);
            var output = compiler.Compile();

            return output.Last();
        }
        static long Day9Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day09.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            Compiler compiler = new Compiler(seed, 2);
            var output = compiler.Compile();

            return output.Last();
        } 


        static int Day10Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day10.txt");
            List<string> lines = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                //var pair = line.Split(')');
                lines.Add(line);
            }

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[0].Count(); j++)
                {
                    if (lines[i][j] == '#')
                        coords.Add(Tuple.Create(j, i));
                }
            }

            Dictionary<Tuple<int, int>, int> visibleAsteroids = new Dictionary<Tuple<int, int>, int>();
            foreach (var coord in coords)
            {
                var distances = coords.Where(c => c != coord).Select(c => new { x = coord.Item1 - c.Item1, y = coord.Item2 - c.Item2 });
                var reducedDistances = from d in distances
                                       let gcd = Math.Abs(GCD(d.x, d.y))
                                       select new { x = d.x / gcd, y = d.y / gcd };

                var uniqueDistances = reducedDistances.Distinct();

                visibleAsteroids.Add(coord, uniqueDistances.Count());
            }

            var orderedVisAst = visibleAsteroids.OrderBy(q => q.Value).ToList();
            var mostVis = orderedVisAst.Last();
            return mostVis.Value;
        }
        static int GCD(int x, int y)
        {
            while (y != 0)
            {
                int tmp = x % y;
                x = y;
                y = tmp;
            }

            return x;
        }
        static int Day10Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day10.txt");
            List<string> lines = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                //var pair = line.Split(')');
                lines.Add(line);
            }

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[0].Count(); j++)
                {
                    if (lines[i][j] == '#')
                        coords.Add(Tuple.Create(j, i));
                }
            }

            //Dictionary<Tuple<int, int>, int> visibleAsteroids = new Dictionary<Tuple<int, int>, int>();
            //foreach (var coord in coords)
            //{
            //    var distances = coords.Where(c => c != coord).Select(c => new { x = coord.Item1 - c.Item1, y = coord.Item2 - c.Item2 });
            //    var reducedDistances = from d in distances
            //                           let gcd = Math.Abs(GCD(d.x, d.y))
            //                           select new { x = d.x / gcd, y = d.y / gcd };

            //    var uniqueDistances = reducedDistances.Distinct();
            //    visibleAsteroids.Add(coord, uniqueDistances.Count());
            //}

            //var orderedVisAst = visibleAsteroids.OrderBy(q => q.Value).ToList();
            //var mostVis = orderedVisAst.Last();


            var bestCoords = Tuple.Create(26, 36); // mostVis.Key;
            var relativeCoords = coords.Where(c => c != bestCoords).Select(c => new { x = bestCoords.Item1 - c.Item1, y = bestCoords.Item2 - c.Item2 });

            var polarCoords = relativeCoords.Select(c => new { theta = Math.Atan2(c.y, c.x), r = Hypotenuse(c.x, c.y) }); //Math.Atan((double)c.y / c.x)
            var modifiedPolar = polarCoords.Select(p => new { theta = ((Math.PI * 5 / 2) - p.theta) % (Math.PI * 2), p.r }).ToList();
            var groupedPolar = modifiedPolar.GroupBy(p => p.theta).SelectMany(g => g.Select((coord, occur) => new { theta = coord.theta + (10 * occur), coord.r })); //, occur }));
            var orderedPolar = groupedPolar.OrderBy(p => p.theta).ToList();//.ThenBy(p => p.r).ToList();

            var asteroid = orderedPolar[199];
            var test2 = modifiedPolar.OrderBy(t => t.theta).ToList();
            var index = modifiedPolar.FindIndex(p => p.theta == asteroid.theta && p.r == asteroid.r);
            var test = coords[index];

            var relativeCartesian = new { x = asteroid.r * Math.Cos(asteroid.theta), y = asteroid.r * Math.Sin(asteroid.theta) };
            var trueCartesian = new { x = (int)Math.Round(bestCoords.x - relativeCartesian.x), y = (int)Math.Round(bestCoords.y - relativeCartesian.y) };
            return trueCartesian.x * 100 + trueCartesian.y;
        }

        static double Hypotenuse(int x, int y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }


        static int Day11Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day11.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            var dirRot = new List<char>() { 'U', 'R', 'D', 'L', 'U', 'R', 'D', 'L', 'U' };

            List<Tuple<int, int>> black = new List<Tuple<int, int>>();
            List<Tuple<int, int>> white = new List<Tuple<int, int>>();

            var curLoc = Tuple.Create(0, 0);
            long curCol = 0;
            var curDir = 'U';

            Compiler compiler = new Compiler(seed);            
            while (!compiler.HasTerminated)
            {
                compiler.AddInputs(curCol);
                var output = compiler.Compile();

                if (output[0] == 0)
                {
                    black.Add(curLoc);
                    white.Remove(curLoc);
                }
                else
                {
                    white.Add(curLoc);
                    black.Remove(curLoc);
                }

                if(output[1] == 0)
                {
                    curDir = dirRot[dirRot.IndexOf(curDir) + 4 - 1];
                }
                else
                {
                    curDir = dirRot[dirRot.IndexOf(curDir) + 4 + 1];
                }

                switch (curDir)
                {
                    case 'U':
                        curLoc = Tuple.Create(curLoc.Item1, curLoc.Item2 + 1);
                        break;
                    case 'R':
                        curLoc = Tuple.Create(curLoc.Item1 + 1, curLoc.Item2);
                        break;
                    case 'D':
                        curLoc = Tuple.Create(curLoc.Item1, curLoc.Item2 - 1);
                        break;
                    case 'L':
                        curLoc = Tuple.Create(curLoc.Item1 - 1, curLoc.Item2);
                        break;
                }


                curCol = white.Contains(curLoc) ? 1 : 0;
            }

            black = black.Distinct().ToList();
            white = white.Distinct().ToList();

            return black.Count() + white.Count();
        }
        static void Day11Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day11.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            var dirRot = new List<char>() { 'U', 'R', 'D', 'L', 'U', 'R', 'D', 'L', 'U' };

            List<Tuple<int, int>> black = new List<Tuple<int, int>>();
            List<Tuple<int, int>> white = new List<Tuple<int, int>>() { Tuple.Create(0, 0) };

            var curLoc = Tuple.Create(0, 0);
            long curCol = 1;
            var curDir = 'U';

            Compiler compiler = new Compiler(seed);
            do
            {
                compiler.AddInputs(curCol);
                var output = compiler.Compile();

                if (output[0] == 0)
                {
                    black.Add(curLoc);
                    white.Remove(curLoc);
                }
                else
                {
                    white.Add(curLoc);
                    black.Remove(curLoc);
                }

                if (output[1] == 0)
                {
                    curDir = dirRot[dirRot.IndexOf(curDir) + 4 - 1];
                }
                else
                {
                    curDir = dirRot[dirRot.IndexOf(curDir) + 4 + 1];
                }

                switch (curDir)
                {
                    case 'U':
                        curLoc = Tuple.Create(curLoc.Item1, curLoc.Item2 - 1);
                        break;
                    case 'R':
                        curLoc = Tuple.Create(curLoc.Item1 + 1, curLoc.Item2);
                        break;
                    case 'D':
                        curLoc = Tuple.Create(curLoc.Item1, curLoc.Item2 + 1);
                        break;
                    case 'L':
                        curLoc = Tuple.Create(curLoc.Item1 - 1, curLoc.Item2);
                        break;
                }


                curCol = white.Contains(curLoc) ? 1 : 0;
            } while (!compiler.HasTerminated);

            var xMax = Math.Min(black.OrderBy(b => b.Item1).Last().Item1, white.OrderBy(w => w.Item1).Last().Item1);
            var yMax = Math.Min(black.OrderBy(b => b.Item2).Last().Item2, white.OrderBy(w => w.Item2).Last().Item2);
            for(int i = 0; i <= yMax; i++)
            {
                string toPrint = "";
                for (int j = 0; j <= xMax; j++)
                {
                    if(white.Any(w => w.Item1 == j && w.Item2 == i))
                    {
                        toPrint += '■';
                    }
                    else
                    {
                        toPrint += ' ';
                    }
                }
                Console.WriteLine(toPrint);
            }
        }



        static int Day12Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day12.txt");
            List<Moon> moons = new List<Moon>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var tempLine = line.Replace("<", "").Replace(">", "").Split(',').Select(x => x.Split('=')).Select(x => new { key = x[0].Trim(), value = int.Parse(x[1]) });//.Select(l => new {key = l[;
                Dictionary<string, int> test = new Dictionary<string, int>();
                foreach (var temp in tempLine)
                {
                    test.Add(temp.key, temp.value);
                }

                moons.Add(new Moon(test["x"], test["y"], test["z"]));
            }

            for (int step = 1; step <= 1000; step++)
            {
                foreach (var moon in moons)
                {
                    var xChange = moons.Count(m => m.PosX > moon.PosX) - moons.Count(m => m.PosX < moon.PosX);
                    var yChange = moons.Count(m => m.PosY > moon.PosY) - moons.Count(m => m.PosY < moon.PosY);
                    var zChange = moons.Count(m => m.PosZ > moon.PosZ) - moons.Count(m => m.PosZ < moon.PosZ);


                    moon.PrepMove(xChange, yChange, zChange);
                }

                moons.ForEach(m => m.Move());

                //if (step % 10 == 0)
                //{
                //    Console.WriteLine($"After {step} steps:");
                //    moons.ForEach(m => Console.WriteLine($"pos={m.GetPos()}, vel={m.GetVel()}"));
                //}
            }

            int totalEnergy = 0;
            foreach (var moon in moons)
            {
                totalEnergy += moon.Energy();
            }

            return totalEnergy;



        }
        static int Day12Puzzle2()
        {

            var file = new StreamReader(@"..\..\Data\Day12.txt");
            List<Moon> moons = new List<Moon>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var tempLine = line.Replace("<", "").Replace(">", "").Split(',').Select(x => x.Split('=')).Select(x => new { key = x[0].Trim(), value = int.Parse(x[1]) });//.Select(l => new {key = l[;
                Dictionary<string, int> test = new Dictionary<string, int>();
                foreach (var temp in tempLine)
                {
                    test.Add(temp.key, temp.value);
                }

                moons.Add(new Moon(test["x"], test["y"], test["z"]));
            }


            List<int> OriginX = new List<int>();
            List<int> OriginY = new List<int>();
            List<int> OriginZ = new List<int>();
            foreach(var moon in moons)
            {
                OriginX.AddRange(moon.GetX());
                OriginY.AddRange(moon.GetY());
                OriginZ.AddRange(moon.GetZ());
            }

            int freqX = 0;
            int freqY = 0;
            int freqZ = 0;
            int step = 0;
            while (freqX == 0 || freqY == 0 || freqZ == 0)
            {
                foreach (var moon in moons)
                {
                    var xChange = moons.Count(m => m.PosX > moon.PosX) - moons.Count(m => m.PosX < moon.PosX);
                    var yChange = moons.Count(m => m.PosY > moon.PosY) - moons.Count(m => m.PosY < moon.PosY);
                    var zChange = moons.Count(m => m.PosZ > moon.PosZ) - moons.Count(m => m.PosZ < moon.PosZ);


                    moon.PrepMove(xChange, yChange, zChange);
                }

                moons.ForEach(m => m.Move());
                step++;

                List<int> NewX = new List<int>();
                List<int> NewY = new List<int>();
                List<int> NewZ = new List<int>();
                foreach (var moon in moons)
                {
                    NewX.AddRange(moon.GetX());
                    NewY.AddRange(moon.GetY());
                    NewZ.AddRange(moon.GetZ());
                }

                if (freqX == 0 && OriginX.SequenceEqual(NewX))
                {
                    freqX = step;
                }
                if (freqY == 0 && OriginY.SequenceEqual(NewY))
                {
                    freqY = step;
                }
                if (freqZ == 0 && OriginZ.SequenceEqual(NewZ))
                {
                    freqZ = step;
                }

            }

            var factors = new int[] { freqX, freqY, freqZ };
            var returner = LCM(factors);

            return returner;
        }

        static int LCM(int[] factors) //Need to fix, had to use only tool to find LCM
        {
            int runningGCD = factors[0];
            long product = factors[0];
            for(int i = 1; i < factors.Length; i++)
            {
                runningGCD = GCD(runningGCD, factors[i]);
                product *= factors[i];
            }

            var result = product / runningGCD;
            return (int)result;
        }

        static int Day13Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day13.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();

            Compiler compiler = new Compiler(seed);
            var output = compiler.Compile();

            var coords = new List<List<long>>();
            while (output.Any())
            {
                coords.Add(output.Take(3).ToList());
                output = output.Skip(3).ToList();
            }


            var empty = coords.Where(c => c[2] == 0).ToList();
            var wall = coords.Where(c => c[2] == 1).ToList();
            var block = coords.Where(c => c[2] == 2).ToList();
            var paddle = coords.Where(c => c[2] == 3).ToList();
            var ball = coords.Where(c => c[2] == 4).ToList();

            return block.Count();
        }
        static long Day13Puzzle2()
        {
            var file = new StreamReader(@"..\..\Data\Day13.txt");
            string fileText = file.ReadToEnd();
            var seed = fileText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(f => long.Parse(f)).ToList();
            seed[0] = 2;

            Compiler compiler = new Compiler(seed);

            long score = 0;
            var toPrint = Enumerable.Range(0, 20).Select(x => Enumerable.Repeat(' ', 44).ToArray()).ToArray();
            var paddle = new List<long>();
            var ball = new List<long>();
            while (!compiler.HasTerminated)
            {
                var output = compiler.Compile();

                var coords = new List<List<long>>();
                while (output.Any())
                {
                    coords.Add(output.Take(3).ToList());
                    output = output.Skip(3).ToList();
                }

                var scoreCoord = coords.FirstOrDefault(c => c[0] == -1 && c[1] == 0);
                coords = coords.Where(c => c != scoreCoord).ToList();
                score = scoreCoord?[2] ?? score;


                //var xMin = coords.OrderBy(c => c[1]).First()[1];
                //var xMax = coords.OrderBy(c => c[1]).Last()[1];
                //var yMin = coords.OrderBy(c => c[0]).First()[0];
                //var yMax = coords.OrderBy(c => c[0]).Last()[0];

                //var empty = coords.Where(c => c[2] == 0).ToList();
                //var wall = coords.Where(c => c[2] == 1).ToList();
                //var block = coords.Where(c => c[2] == 2).ToList();
                paddle = coords.FirstOrDefault(c => c[2] == 3) ?? paddle;
                ball = coords.FirstOrDefault(c => c[2] == 4) ?? ball;


                //for (int i = 0; i <= 19; i++)
                //{
                //    var line = new string(' ', 44).ToArray();
                //    for (int j = 0; j <= 43; j++)
                //    {
                //        if (wall.Any(w => w[0] == j && w[1] == i))
                //        {
                //            toPrint[i][j] = '#';
                //        }
                //        else if (block.Any(b => b[0] == j && b[1] == i))
                //        {
                //            toPrint[i][j] = 'X';
                //        }
                //        else if (paddle != null && paddle[0] == j && paddle[1] == i)
                //        {
                //            toPrint[i][j] = '-';
                //        }
                //        else if (ball != null && ball[0] == j && ball[1] == i)
                //        {
                //            toPrint[i][j] = '*';
                //        }
                //        else if (empty.Any(e => e[0] == j && e[1] == i))
                //        {
                //            toPrint[i][j] = ' ';
                //        }
                //    }
                //    Console.WriteLine(toPrint[i]);
                //}

                //Console.WriteLine($"Score: {score}");
                compiler.AddInputs(Math.Sign(ball[0] - paddle[0]));
            }
            return score;
        }

        static int Day14Puzzle1()
        {
            var file = new StreamReader(@"..\..\Data\Day14.txt");
            List<Moon> moons = new List<Moon>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var tempLine = line.Replace("<", "").Replace(">", "").Split(',').Select(x => x.Split('=')).Select(x => new { key = x[0].Trim(), value = int.Parse(x[1]) });//.Select(l => new {key = l[;
                Dictionary<string, int> test = new Dictionary<string, int>();
                foreach (var temp in tempLine)
                {
                    test.Add(temp.key, temp.value);
                }

                moons.Add(new Moon(test["x"], test["y"], test["z"]));
            }



            return 0;
        }
        static int Day14Puzzle2()
        {

            return 0;
        }

        //static int Day10Puzzle1()
        //{

        //    return 0;
        //}
        //static int Day10Puzzle2()
        //{

        //    return 0;
        //}

    }




    public class Compiler
    {
        private int curPos;
        private int inputStep;
        private long relativeBase;
        private List<long> seed;
        private List<long> inputs;

        public bool HasTerminated { get; private set; }

        public Compiler()
        {
            seed = new List<long>();
            inputs = new List<long>();
        }

        public Compiler(List<long> seed, params long[] inputs)
        {
            this.seed = seed;
            this.inputs = inputs.ToList();
        }

        public void AddInputs(params long[] inputs)
        {
            this.inputs.AddRange(inputs);
        }
               
        public void Seed(List<long> seed)
        {
            this.seed = seed;
        }

        public List<long> Compile()
        {
            List<long> returner = new List<long>();
            while (curPos < seed.Count())
            {
                int steps = 0;
                var instructions = seed[curPos].ToString().Select(d => int.Parse(d.ToString())).Reverse().ToList();
                instructions[0] = instructions.ElementAtOrDefault(1) * 10 + instructions[0];
                if (instructions.Count() > 1)
                    instructions.RemoveAt(1);

                var pos1Mode = instructions.ElementAtOrDefault(1);
                var pos1Offset = pos1Mode == 2 ? (int)relativeBase : 0;
                var pos1 = pos1Mode == 1 ? curPos + 1 : (int)(seed.ElementAtOrDefault(curPos + 1) + pos1Offset);

                var pos2Mode = instructions.ElementAtOrDefault(2);
                var pos2Offset = pos2Mode == 2 ? (int)relativeBase : 0;
                var pos2 = pos2Mode == 1 ? curPos + 2 : (int)(seed.ElementAtOrDefault(curPos + 2) + pos2Offset);

                var pos3Mode = instructions.ElementAtOrDefault(3);
                var pos3Offset = pos3Mode == 2 ? (int)relativeBase : 0;
                var pos3 = pos3Mode == 1 ? curPos + 3 : (int)(seed.ElementAtOrDefault(curPos + 3) + pos3Offset);

                var maxRange = Math.Max(pos1, pos2);

                var input3 = new List<int>() { 1, 2, 7, 8 };
                if (input3.Contains(instructions[0]))
                {
                    maxRange = Math.Max(maxRange, pos3);
                }

                if(seed.Count() <= maxRange)
                {
                    seed.AddRange(Enumerable.Repeat((long)0, maxRange - seed.Count() + 1));
                }


                #region Switch
                switch (instructions[0])
                {
                    case 1: //add
                        {
                            steps = 4;
                            seed[pos3] = seed[pos1] + seed[pos2];
                            break;
                        }
                    case 2: //multiply
                        {
                            steps = 4;
                            seed[pos3] = seed[pos1] * seed[pos2];
                            break;
                        }
                    case 3: //input
                        {
                            steps = 2;
                            if (inputStep < inputs.Count())
                            {
                                var temp = inputs[inputStep];
                                inputStep++;
                                seed[pos1] = temp;
                            }
                            else
                            {
                                return returner;
                            }
                        }
                        break;
                    case 4: //output
                        {
                            steps = 2;
                            returner.Add(seed[pos1]);
                        }
                        break;
                    case 5: //jump if true
                        {
                            steps = 3;                            
                            if (seed[pos1] != 0)
                            {
                                steps = 0;
                                curPos = (int)seed[pos2];
                            }
                        }
                        break;
                    case 6: //jump if false
                        {
                            steps = 3;                            
                            if (seed[pos1] == 0)
                            {
                                steps = 0;
                                curPos = (int)seed[pos2];
                            }
                        }
                        break;
                    case 7: //less than
                        {
                            steps = 4;
                            seed[pos3] = seed[pos1] < seed[pos2] ? 1 : 0;
                        }
                        break;
                    case 8: //equals
                        {
                            steps = 4;                            
                            seed[pos3] = seed[pos1] == seed[pos2] ? 1 : 0;
                        }
                        break;
                    case 9:
                        {
                            steps = 2;
                            relativeBase += seed[pos1];
                        }
                        break;
                    case 99: //exit
                        HasTerminated = true;
                        return returner;
                    default: //we fucked up
                        return null;
                }
                #endregion

                curPos += steps;
            }

            return returner;
        }
    }


    public class Moon
    {
        public int PosX;
        public int PosY;
        public int PosZ;

        public int VelX;
        public int VelY;
        public int VelZ;

        public int AccelX;
        public int AccelY;
        public int AccelZ;

        public Moon(int x, int y, int z)
        {
            PosX = x;
            PosY = y;
            PosZ = z;

            VelX = 0;
            VelY = 0;
            VelZ = 0;

        }


        public void Move(int x, int y, int z)
        {
            VelX += x;
            VelY += y;
            VelZ += z;

            PosX += VelX;
            PosY += VelY;
            PosZ += VelZ;

            AccelX = 0;
            AccelY = 0;
            AccelZ = 0;
        }

        public void PrepMove(int x, int y, int z)
        {
            AccelX = x;
            AccelY = y;
            AccelZ = z;
        }

        public void Move()
        {
            VelX += AccelX;
            VelY += AccelY;
            VelZ += AccelZ;

            PosX += VelX;
            PosY += VelY;
            PosZ += VelZ;

            AccelX = 0;
            AccelY = 0;
            AccelZ = 0;
        }

        public int Energy()
        {
            int potential = Math.Abs(PosX) + Math.Abs(PosY) + Math.Abs(PosZ);
            int kinetic = Math.Abs(VelX) + Math.Abs(VelY) + Math.Abs(VelZ);

            return potential * kinetic;
        }


        public string GetPos()
        {
            return $"<x={PosX}, y={PosY}, z={PosZ}>";
        }

        public string GetVel()
        {
            return $"<x={VelX}, y={VelY}, z={VelZ}>";
        }

        public List<int> GetX()
        {
            return new List<int>() { PosX, VelX };
        }
        public List<int> GetY()
        {
            return new List<int>() { PosY, VelY };
        }
        public List<int> GetZ()
        {
            return new List<int>() { PosZ, VelZ };
        }
    }
}
