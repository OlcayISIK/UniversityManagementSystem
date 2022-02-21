using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Core.Enums
{
    public enum ErrorCode
    {
        InvalidUsernameOrPassword = 101,
        InvalidRefreshToken = 102,
        InvalidPasswordResetToken = 103,
        InvalidAction = 104,

        ReservationCancelTimeHasExpired = 201,
        CanNotOrderFromMultipleCompanies = 202,
        ItemIsAlreadyPaidFor = 203,
        RestaurantIsClosed = 204,
        NotAllowedForGuestUser = 205,
        PermissionDenied = 206,

        ObjectNotFound = 404,
        ObjectAlreadyExists = 405,
        ObjectIsDefault = 406,
        InternalServerError = 500
    }
}
