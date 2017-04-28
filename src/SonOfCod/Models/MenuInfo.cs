using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCod.Models
{
    [Table("MenuInfo")]
    public class MenuInfo
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public MenuInfo()
        {
            Url = "http://j2k.repo.nypl.org/adore-djatoka/resolver?url_ver=Z39.88-2004&rft_id=urn:uuid:ae2f51ec-bd49-66c6-e040-e00a18066cf3&svc_id=info:lanl-repo/svc/getRegion&svc_val_fmt=info:ofi/fmt:kev:mtx:jpeg2000&svc.format=image/jpeg&svc.scale=1800,0&svc.rotate=0";
        }
    }
}
