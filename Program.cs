using BinarySearchTrees_AVL;
using System.Diagnostics;

var test = new BST();
CountTime(test);

static BST CreateTestData(int amount, BST tree)
{
    Random randNum = new Random();
    for (int i = 0; i < amount; i++)
    {
        tree.Insert(i);
        //tree.Insert(randNum.Next(0, 1000));
    }
    return tree;
}
static void CountTime(BST tree)
{
    Stopwatch clock = new Stopwatch();
    clock.Start();
    tree = CreateTestData(1000, tree);
    clock.Stop();
    Console.WriteLine($"Наполнение возрастающими числами от 0 до 1000 {clock.ElapsedMilliseconds} ms");
    clock.Start();
    SearchData(100, tree);
    clock.Stop();
    Console.WriteLine($"Поиск случайных чисел от 0 до 100 {clock.ElapsedMilliseconds} ms");
    clock.Start();
    tree = DeleteData(1000, tree);
    clock.Stop();
    Console.WriteLine($"Удаление случайных чисел от 0 до 100 {clock.ElapsedMilliseconds} ms");

}
static void SearchData(int amount, BST tree)
{
    Random randNum = new Random();
    for (int i = 0; i < amount; i++)
    {
        tree.Search(randNum.Next(0, 1000));
    }
}
static BST DeleteData(int amount, BST tree)
{
    Random randNum = new Random();
    for (int i = 0; i < amount; i++)
    {
        tree.Remove(randNum.Next(0, 1000));
    }
    return tree;
}