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
    public class R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1 : QueryBasis<R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0APOLCLAUSULA
            VALUES (:V0APCL-COD-EMPRESA:VIND-COD-EMP,
            :V0APCL-NUM-APOL,
            :V0APCL-NRENDOS,
            :V0APCL-RAMOFR,
            :V0APCL-MODALIFR,
            :V0APCL-COD-COBERT,
            :V0APCL-DTINIVIG,
            :V0APCL-DTTERVIG,
            :V0APCL-NRITEM,
            :V0APCL-CODCLAUS,
            :V0APCL-TIPOCLAU,
            :V0APCL-LIM-IND-IX,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCLAUSULA VALUES ( {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0APCL_COD_EMPRESA))}, {FieldThreatment(this.V0APCL_NUM_APOL)}, {FieldThreatment(this.V0APCL_NRENDOS)}, {FieldThreatment(this.V0APCL_RAMOFR)}, {FieldThreatment(this.V0APCL_MODALIFR)}, {FieldThreatment(this.V0APCL_COD_COBERT)}, {FieldThreatment(this.V0APCL_DTINIVIG)}, {FieldThreatment(this.V0APCL_DTTERVIG)}, {FieldThreatment(this.V0APCL_NRITEM)}, {FieldThreatment(this.V0APCL_CODCLAUS)}, {FieldThreatment(this.V0APCL_TIPOCLAU)}, {FieldThreatment(this.V0APCL_LIM_IND_IX)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APCL_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0APCL_NUM_APOL { get; set; }
        public string V0APCL_NRENDOS { get; set; }
        public string V0APCL_RAMOFR { get; set; }
        public string V0APCL_MODALIFR { get; set; }
        public string V0APCL_COD_COBERT { get; set; }
        public string V0APCL_DTINIVIG { get; set; }
        public string V0APCL_DTTERVIG { get; set; }
        public string V0APCL_NRITEM { get; set; }
        public string V0APCL_CODCLAUS { get; set; }
        public string V0APCL_TIPOCLAU { get; set; }
        public string V0APCL_LIM_IND_IX { get; set; }

        public static void Execute(R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1 r2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1)
        {
            var ths = r2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}