using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0911S
{
    public class R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1 : QueryBasis<R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0OUTROSCOBER
            VALUES (:V0APOC-COD-EMPRESA,
            :V0APOC-FONTE ,
            :V0APOC-NRPROPOS ,
            :V0APOC-NRRISCO ,
            :V0APOC-RAMOFR ,
            :V0APOC-MODALIFR ,
            :V0APOC-COD-COBER ,
            :V0APOC-DTINIVIG ,
            :V0APOC-DTTERVIG ,
            :V0APOC-IMP-SEG-IX ,
            :V0APOC-IMP-SEG-VR ,
            :V0APOC-TAXA-IS ,
            :V0APOC-PRM-ANU-IX ,
            :V0APOC-PRM-TAR-IX ,
            :V0APOC-PRM-TAR-VR ,
            :V0APOC-VRFROBR-IX ,
            :V0APOC-LIM-IND-IX ,
            :V0APOC-SITUACAO ,
            :V0APOC-NUM-APOL ,
            :V0APOC-NRENDOS ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0OUTROSCOBER VALUES ({FieldThreatment(this.V0APOC_COD_EMPRESA)}, {FieldThreatment(this.V0APOC_FONTE)} , {FieldThreatment(this.V0APOC_NRPROPOS)} , {FieldThreatment(this.V0APOC_NRRISCO)} , {FieldThreatment(this.V0APOC_RAMOFR)} , {FieldThreatment(this.V0APOC_MODALIFR)} , {FieldThreatment(this.V0APOC_COD_COBER)} , {FieldThreatment(this.V0APOC_DTINIVIG)} , {FieldThreatment(this.V0APOC_DTTERVIG)} , {FieldThreatment(this.V0APOC_IMP_SEG_IX)} , {FieldThreatment(this.V0APOC_IMP_SEG_VR)} , {FieldThreatment(this.V0APOC_TAXA_IS)} , {FieldThreatment(this.V0APOC_PRM_ANU_IX)} , {FieldThreatment(this.V0APOC_PRM_TAR_IX)} , {FieldThreatment(this.V0APOC_PRM_TAR_VR)} , {FieldThreatment(this.V0APOC_VRFROBR_IX)} , {FieldThreatment(this.V0APOC_LIM_IND_IX)} , {FieldThreatment(this.V0APOC_SITUACAO)} , {FieldThreatment(this.V0APOC_NUM_APOL)} , {FieldThreatment(this.V0APOC_NRENDOS)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APOC_COD_EMPRESA { get; set; }
        public string V0APOC_FONTE { get; set; }
        public string V0APOC_NRPROPOS { get; set; }
        public string V0APOC_NRRISCO { get; set; }
        public string V0APOC_RAMOFR { get; set; }
        public string V0APOC_MODALIFR { get; set; }
        public string V0APOC_COD_COBER { get; set; }
        public string V0APOC_DTINIVIG { get; set; }
        public string V0APOC_DTTERVIG { get; set; }
        public string V0APOC_IMP_SEG_IX { get; set; }
        public string V0APOC_IMP_SEG_VR { get; set; }
        public string V0APOC_TAXA_IS { get; set; }
        public string V0APOC_PRM_ANU_IX { get; set; }
        public string V0APOC_PRM_TAR_IX { get; set; }
        public string V0APOC_PRM_TAR_VR { get; set; }
        public string V0APOC_VRFROBR_IX { get; set; }
        public string V0APOC_LIM_IND_IX { get; set; }
        public string V0APOC_SITUACAO { get; set; }
        public string V0APOC_NUM_APOL { get; set; }
        public string V0APOC_NRENDOS { get; set; }

        public static void Execute(R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1 r2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1)
        {
            var ths = r2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}