using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1 : QueryBasis<R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COBERINC
            VALUES (:V0COBI-COD-EMPRESA ,
            :V0COBI-NUM-APOL ,
            :V0COBI-NRENDOS ,
            :V0COBI-NUM-RISCO ,
            :V0COBI-SUBRIS ,
            :V0COBI-NRITEM ,
            :V0COBI-CODCOBINC ,
            :V0COBI-IMP-SEG-IX ,
            :V0COBI-TIPCOBINC ,
            :V0COBI-PRM-TAR-IX ,
            :V0COBI-PRM-ANU-IX ,
            :V0COBI-PRM-TAR-VR ,
            :V0COBI-DTINIVIG ,
            :V0COBI-DTTERVIG ,
            :V0COBI-SITUACAO ,
            CURRENT TIMESTAMP ,
            :V0COBI-OCORHIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERINC VALUES ({FieldThreatment(this.V0COBI_COD_EMPRESA)} , {FieldThreatment(this.V0COBI_NUM_APOL)} , {FieldThreatment(this.V0COBI_NRENDOS)} , {FieldThreatment(this.V0COBI_NUM_RISCO)} , {FieldThreatment(this.V0COBI_SUBRIS)} , {FieldThreatment(this.V0COBI_NRITEM)} , {FieldThreatment(this.V0COBI_CODCOBINC)} , {FieldThreatment(this.V0COBI_IMP_SEG_IX)} , {FieldThreatment(this.V0COBI_TIPCOBINC)} , {FieldThreatment(this.V0COBI_PRM_TAR_IX)} , {FieldThreatment(this.V0COBI_PRM_ANU_IX)} , {FieldThreatment(this.V0COBI_PRM_TAR_VR)} , {FieldThreatment(this.V0COBI_DTINIVIG)} , {FieldThreatment(this.V0COBI_DTTERVIG)} , {FieldThreatment(this.V0COBI_SITUACAO)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0COBI_OCORHIST)})";

            return query;
        }
        public string V0COBI_COD_EMPRESA { get; set; }
        public string V0COBI_NUM_APOL { get; set; }
        public string V0COBI_NRENDOS { get; set; }
        public string V0COBI_NUM_RISCO { get; set; }
        public string V0COBI_SUBRIS { get; set; }
        public string V0COBI_NRITEM { get; set; }
        public string V0COBI_CODCOBINC { get; set; }
        public string V0COBI_IMP_SEG_IX { get; set; }
        public string V0COBI_TIPCOBINC { get; set; }
        public string V0COBI_PRM_TAR_IX { get; set; }
        public string V0COBI_PRM_ANU_IX { get; set; }
        public string V0COBI_PRM_TAR_VR { get; set; }
        public string V0COBI_DTINIVIG { get; set; }
        public string V0COBI_DTTERVIG { get; set; }
        public string V0COBI_SITUACAO { get; set; }
        public string V0COBI_OCORHIST { get; set; }

        public static void Execute(R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1 r3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1)
        {
            var ths = r3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}