using System.Collections.Generic;

public class Selector : InteriorNode
{
    public override Result Run()
    {
        while (current_child < children.Length)
        {
            var status = children[current_child].Run();
            if (status == Result.SUCCESS)
                return Result.SUCCESS;
            if (status == Result.IN_PROGRESS)
                return Result.IN_PROGRESS;

            current_child++;
        }

        return Result.FAILURE;
    }

    public Selector(IEnumerable<BehaviorTree> children) : base(children)
    {
    }

    public override BehaviorTree Copy()
    {
        return new Selector(CopyChildren());
    }

    public override IEnumerable<BehaviorTree> AllNodes()
    {
        yield return this;
        foreach (var child in children)
            foreach (var node in child.AllNodes())
                yield return node;
    }

}
