using System;

namespace Wipster.Refactoring.Domain.Entities
{
    //Anemic Entities. The domain behaviors have not been modelled here, thus the behaviors are mutable and unpredictable. 
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
