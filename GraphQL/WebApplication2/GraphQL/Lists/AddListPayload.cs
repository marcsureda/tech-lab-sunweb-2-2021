using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.GraphQL.Lists
{
    public record AddListPayload (ItemList list);

    //public class AddListPayload
    //{
    //    public AddListPayload(ItemList list)
    //    {
    //        this.list = list;
    //    }

    //    public ItemList list { get; set; }
    //}
}
