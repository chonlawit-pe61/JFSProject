﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Helpers
{
    public class PaginationHelper
    {
        private RequestPagination _requestPagination;
        public PaginationHelper(RequestPagination requestPagination)
        {
            _requestPagination = requestPagination;
        }
        public ResponsePagination GetPagination()
        {
            ResponsePagination res = new ResponsePagination();
            int startRowIndex = (_requestPagination.ItemsPerPage * (_requestPagination.Page - 1));
            if (startRowIndex < 0)
                startRowIndex = 0;
            res.StartRowIndex = startRowIndex;
            res.ItemsPerPage = _requestPagination.ItemsPerPage;
            res.Page = _requestPagination.Page;
            return res;
        }
    }
    public class RequestPagination
    {
        public int Page { get; set; }
        int itemsPerPage = 30;
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; }
        }

    }
    public class ResponsePagination
    {
        public int Page { get; set; }
        int itemsPerPage = 30;
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; }
        }
        public int StartRowIndex { get; set; }

    }

}
