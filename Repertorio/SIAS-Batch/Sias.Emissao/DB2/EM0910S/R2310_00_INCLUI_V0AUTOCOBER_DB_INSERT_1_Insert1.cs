using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1 : QueryBasis<R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0AUTOCOBER
            VALUES (:V0AUCB-COD-EMPRESA,
            :V0AUCB-FONTE ,
            :V0AUCB-NRPROPOS ,
            :V0AUCB-NRITEM ,
            :V0AUCB-RAMOFR ,
            :V0AUCB-MODALIFR ,
            :V0AUCB-COD-COBER ,
            :V0AUCB-DTINIVIG ,
            :V0AUCB-DTTERVIG ,
            :V0AUCB-IMP-SEG-IX ,
            :V0AUCB-IMP-SEG-VR ,
            :V0AUCB-TAXA-IS ,
            :V0AUCB-PRM-ANU-IX ,
            :V0AUCB-PRM-TAR-IX ,
            :V0AUCB-PRM-TAR-VR ,
            :V0AUCB-SITUACAO ,
            :V0AUCB-NUM-APOL ,
            :V0AUCB-NRENDOS ,
            CURRENT TIMESTAMP ,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0AUTOCOBER VALUES ({FieldThreatment(this.V0AUCB_COD_EMPRESA)}, {FieldThreatment(this.V0AUCB_FONTE)} , {FieldThreatment(this.V0AUCB_NRPROPOS)} , {FieldThreatment(this.V0AUCB_NRITEM)} , {FieldThreatment(this.V0AUCB_RAMOFR)} , {FieldThreatment(this.V0AUCB_MODALIFR)} , {FieldThreatment(this.V0AUCB_COD_COBER)} , {FieldThreatment(this.V0AUCB_DTINIVIG)} , {FieldThreatment(this.V0AUCB_DTTERVIG)} , {FieldThreatment(this.V0AUCB_IMP_SEG_IX)} , {FieldThreatment(this.V0AUCB_IMP_SEG_VR)} , {FieldThreatment(this.V0AUCB_TAXA_IS)} , {FieldThreatment(this.V0AUCB_PRM_ANU_IX)} , {FieldThreatment(this.V0AUCB_PRM_TAR_IX)} , {FieldThreatment(this.V0AUCB_PRM_TAR_VR)} , {FieldThreatment(this.V0AUCB_SITUACAO)} , {FieldThreatment(this.V0AUCB_NUM_APOL)} , {FieldThreatment(this.V0AUCB_NRENDOS)} , CURRENT TIMESTAMP , NULL, NULL)";

            return query;
        }
        public string V0AUCB_COD_EMPRESA { get; set; }
        public string V0AUCB_FONTE { get; set; }
        public string V0AUCB_NRPROPOS { get; set; }
        public string V0AUCB_NRITEM { get; set; }
        public string V0AUCB_RAMOFR { get; set; }
        public string V0AUCB_MODALIFR { get; set; }
        public string V0AUCB_COD_COBER { get; set; }
        public string V0AUCB_DTINIVIG { get; set; }
        public string V0AUCB_DTTERVIG { get; set; }
        public string V0AUCB_IMP_SEG_IX { get; set; }
        public string V0AUCB_IMP_SEG_VR { get; set; }
        public string V0AUCB_TAXA_IS { get; set; }
        public string V0AUCB_PRM_ANU_IX { get; set; }
        public string V0AUCB_PRM_TAR_IX { get; set; }
        public string V0AUCB_PRM_TAR_VR { get; set; }
        public string V0AUCB_SITUACAO { get; set; }
        public string V0AUCB_NUM_APOL { get; set; }
        public string V0AUCB_NRENDOS { get; set; }

        public static void Execute(R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1 r2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1)
        {
            var ths = r2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}