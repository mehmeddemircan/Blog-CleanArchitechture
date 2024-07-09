using Application.Features.UserOperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Models
{
    public class ResponseUserOperationClaimListModel
    {
        public IList<ResponseUserOperationClaimListDto> Items { get; set; }
    }
}
