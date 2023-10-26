using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Constants
{
    public class CardsEndpoints
    {
        public const string GET_CARD = "1/cards/{cardId}";
        public const string GET_ALL_CARDS = "1/lists/{listId}/cards";
        public const string CREATE_CARD = "1/cards";
        public const string DELETE_CARD = "1/cards/{cardId}";
        public const string UPDATE_CARD = "1/cards/{cardId}";
    }
}
