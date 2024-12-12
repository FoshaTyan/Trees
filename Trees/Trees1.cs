
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


public class Trees1
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        TreeNode tree = new TreeNode(1);
        TreeNode tempRoot;
        tempRoot = tree.left = new TreeNode(2);
        tree.right = new TreeNode(3);
        tempRoot.left = new TreeNode(4);
        tempRoot = tempRoot.right = new TreeNode(5);
        tempRoot.left = new TreeNode(6);
        tempRoot.right = new TreeNode(7);
        tempRoot = tree.right.right = new TreeNode(8);
        tempRoot.left = new TreeNode(9);

        List<int> values = new List<int>();
        InOrder(tree, values);

        Console.WriteLine("InOrder обхід: " + string.Join(" ", values));
    }

    public static void InOrder(TreeNode root, List<int> values)
    {
        if (root != null)
        {
            InOrder(root.left, values); 
            values.Add(root.value);    
            InOrder(root.right, values); // Рекурсивный обход правого поддерева
        }
    }
}
