using System;
using System.Collections.Generic;
using System.Text;

public class TreeNode
{
    public int value;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTree
{
    public TreeNode RemoveNode(TreeNode root, int valueToDelete)
    {
        if (root == null)
        {
            return null;
        }

        if (root.value == valueToDelete)
        {
            // без нащадків
            if (root.left == null && root.right == null)
            {
                return null;
            }

            // Якщо один нащадок
            if (root.right == null)
            {
                return root.left;
            }
            if (root.left == null)
            {
                return root.right;
            }

            // Якщо 2 нащадки
            TreeNode smallest = FindMin(root.right);
            root.value = smallest.value;
            root.right = RemoveNode(root.right, smallest.value);
            return root;
        }

        // Рекурсивний пошук вузлів в піддеревах
        root.left = RemoveNode(root.left, valueToDelete);
        root.right = RemoveNode(root.right, valueToDelete);

        return root;
    }

    // Знайти найменший елемент у дереві
    private TreeNode FindMin(TreeNode node)
    {
        while (node.left != null)
        {
            node = node.left;
        }
        return node;
    }
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null)
        {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count; // Кількість вузлів на поточному рівні
            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();

                // Додаємо останній вузол на рівні до результату
                if (i == levelSize - 1)
                {
                    result.Add(node.value);
                }

                // Додавання лівого та правого нащадків до черги
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return result;
    }
}

public class Trees2
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        TreeNode root = new TreeNode(1); 
        root.left = new TreeNode(2);
        root.right = new TreeNode(3); 
        root.left.right = new TreeNode(5); 
        root.right.right = new TreeNode(4); 

        BinaryTree tree = new BinaryTree();

        while (true)
        {
            IList<int> rightView = tree.RightSideView(root);
            Console.WriteLine("Вид праворуч: " + string.Join(", ", rightView));

            Console.WriteLine("Значення для видалення (end кінець):");
            string input = Console.ReadLine();
            if (input.ToLower() == "end")
            {
                break;
            }

            if (int.TryParse(input, out int val))
            {
                root = tree.RemoveNode(root, val);
            }
            else
            {
                Console.WriteLine("Некоректне значення.");
            }
        }
    }
}