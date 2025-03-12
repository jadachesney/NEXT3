using Microsoft.EntityFrameworkCore;

namespace NEXTGroup3.Models
{
    [Keyless]
    public class DepartmentRangeQuestion
    {
        // RANGE QUESTION ID
        private int rangeQuestionId;
        public int RangeQuestionId { get { return rangeQuestionId; } set { rangeQuestionId = value; } }

        // DEPARTMENT ID
        private int departmentId;
        public int DepartmentId { get { return departmentId; } set { departmentId = value; } }

        // ALIGNMENT    
        private bool alignment;
        public bool Alignment { get { return alignment; } set { alignment = value; } }
    }
}
