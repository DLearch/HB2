using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class HomeAccounting
    {

        public HomeAccounting()
        {
            Connect("net.tcp://localhost:4000/IContract");
        }

        #region IContract

        IContract channel;

        void Connect(string uri)
        {
            Uri address = new Uri(uri);
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, endpoint);
            channel = factory.CreateChannel();
        }

        #endregion

        #region Error

        string error;

        public string LastError
        {
            get { return error; }
        }

        #endregion

        #region User

        public bool Authentication(string email, string password)
        {
            if (!channel.Authentication(email, password))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool Registration(string name, string email, string password)
        {
            if (!channel.Registration(name, email, password))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!channel.ChangePassword(oldPassword, newPassword))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public void SignOut()
        {
            channel.SignOut();
        }

        #endregion

        #region Categories

        public List<Category> Categories
        {
            get
            {
                List<Category> categories = channel.GetListCategories();
                if (categories == null)
                    error = channel.GetLastError();
                return categories;
            }
        }

        public bool AddCategory(Category category)
        {
            if (!channel.AddCategory(category))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool EditCategory(Category category)
        {
            if (!channel.EditCategory(category))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool RemoveCategory(int id)
        {
            if (!channel.RemoveCategory(id))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        #endregion

        #region FamilyMembers
        
        public List<FamilyMember> FamilyMembers
        {
            get
            {
                List<FamilyMember> familyMembers = channel.GetListFamilyMembers();
                if (familyMembers == null)
                    error = channel.GetLastError();
                return familyMembers;
            }
        }

        public bool AddFamilyMember(string name)
        {
            if (!channel.AddFamilyMember(name))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool EditFamilyMember(FamilyMember familyMember)
        {
            if (!channel.EditFamilyMember(familyMember))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool RemoveFamilyMember(int id)
        {
            if (!channel.RemoveFamilyMember(id))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        #endregion

        #region Orders

        public List<Order> Orders
        {
            get
            {
                List<Order> orders = channel.GetListOrders();
                if (orders == null)
                    error = channel.GetLastError();
                return orders;
            }
        }

        public bool AddOrder(Order order)
        {
            if (!channel.AddOrder(order))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool EditOrder(Order order)
        {
            if (!channel.EditOrder(order))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public bool RemoveOrder(int id)
        {
            if (!channel.RemoveOrder(id))
            {
                error = channel.GetLastError();
                return false;
            }
            return false;
        }

        public Order GetOrder(int id)
        {
            if(!Orders.Any(o => o.Id == id))
                return Orders.First(o => o.Id == id);

            error = "Операція не знайдена.";
            return null;
        }

        #endregion

        #region OrdersViews
        
        public List<OrderView> OrdersViews
        {
            get
            {
                return Orders.Select(o => new OrderView() {
                                Id = o.Id,
                                CategoryName = Categories.First(c => c.Id == o.CategoryId).Name,
                                FamilyMemberName = FamilyMembers.First(fm => fm.Id == o.FamilyMemberId).Name,
                                Date = o.Date.ToShortDateString(),
                                Description = o.Description,
                                Price = o.Price.ToString()
                             })
                             .ToList();
            }
        }
        
        #endregion

        #region Filters

        public event Action FiltersUpdated;

        #region FilterCategories Property

        List<Category> filterCategories = null;
        public List<Category> FilterCategories
        {
            get
            {
                return filterCategories;
            }
            set
            {
                filterCategories = value;
                FiltersUpdated();
            }
        }

        #endregion
        #region FilterFamilyMembers Property

        List<FamilyMember> filterFamilyMembers = null;
        public List<FamilyMember> FilterFamilyMembers
        {
            get
            {
                return filterFamilyMembers;
            }
            set
            {
                filterFamilyMembers = value;
                FiltersUpdated();
            }
        }

        #endregion
        #region FilterDateFrom Property

        DateTime? filterDateFrom = null;
        public DateTime? FilterDateFrom
        {
            get
            {
                return filterDateFrom;
            }
            set
            {
                filterDateFrom = value;
                FiltersUpdated();
            }
        }

        #endregion
        #region FilterDateTo Property

        DateTime? filterDateTo = null;
        public DateTime? FilterDateTo
        {
            get
            {
                return filterDateTo;
            }
            set
            {
                filterDateTo = value;
                FiltersUpdated();
            }
        }

        #endregion
        #region FilterPriceFrom Property

        decimal? filterPriceFrom = null;
        public decimal? FilterPriceFrom
        {
            get
            {
                return filterPriceFrom;
            }
            set
            {
                filterPriceFrom = value;
                FiltersUpdated();
            }
        }

        #endregion
        #region FilterPriceTo Property

        decimal? filterPriceTo = null;
        public decimal? FilterPriceTo
        {
            get
            {
                return filterPriceTo;
            }
            set
            {
                filterPriceTo = value;
                FiltersUpdated();
            }
        }

        #endregion
        #region FilterIsIncome Property

        bool? filterIsIncome = null;
        public bool? FilterIsIncome
        {
            get
            {
                return filterIsIncome;
            }
            set
            {
                filterIsIncome = value;
                FiltersUpdated();
            }
        }

        #endregion

        public List<OrderView> FilteredOrdersViews
        {
            get
            {
                List<OrderView> ordersViews = new List<OrderView>();

                foreach (var orderView in OrdersViews)
                {
                    Order order = Orders.First(o => o.Id == orderView.Id);

                    if ((FilterCategories == null || FilterCategories.Count == 0 || FilterCategories.Any(c => c.Id == order.CategoryId))
                        && (FilterFamilyMembers == null || FilterFamilyMembers.Count == 0 || FilterFamilyMembers.Any(fm => fm.Id == order.FamilyMemberId))
                        && (FilterDateFrom == null || FilterDateFrom <= order.Date)
                        && (FilterDateTo == null || FilterDateTo >= order.Date)
                        && (FilterPriceFrom == null || FilterPriceFrom <= order.Price)
                        && (FilterPriceTo == null || FilterPriceTo >= order.Price)
                        && (FilterIsIncome == null || FilterIsIncome == Categories.First(c => c.Id == order.CategoryId).Type))
                        ordersViews.Add(orderView);
                }

                return ordersViews;
            }
        }

        public void ApplyFilters(List<Category> categories, List<FamilyMember> familyMembers = null, DateTime? dateFrom = null, DateTime? dateTo = null, decimal? priceFrom = null, decimal? priceTo = null, bool? isIncome = null)
        {
            filterCategories = categories;
            filterFamilyMembers = familyMembers;
            filterDateFrom = dateFrom;
            filterDateTo = dateTo;
            filterPriceFrom = priceFrom;
            filterPriceTo = priceTo;
            filterIsIncome = isIncome;

            FiltersUpdated();
        }

        public void ApplyFiltersDate(DateTime? dateFrom, DateTime? dateTo = null)
        {
            filterDateFrom = dateFrom;
            filterDateTo = dateTo;

            FiltersUpdated();
        }

        public void ApplyFiltersPrice(decimal? priceFrom, decimal? priceTo = null)
        {
            filterPriceFrom = priceFrom;
            filterPriceTo = priceTo;

            FiltersUpdated();
        }

        public decimal GetFilteredOrdersViewsPriceSum()
        {
            return FilteredOrdersViews.Sum(ov => Orders.First(o => o.Id == ov.Id).Price);
        }

        #endregion
    }
}
