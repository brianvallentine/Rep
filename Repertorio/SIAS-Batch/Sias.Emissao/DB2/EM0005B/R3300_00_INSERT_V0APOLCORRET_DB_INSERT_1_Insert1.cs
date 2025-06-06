using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1 : QueryBasis<R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLCORRET
            VALUES (:V0ACOR-NUM-APOL ,
            :V0ACOR-RAMOFR ,
            :V0ACOR-MODALIFR ,
            :V0ACOR-CODCORR ,
            :V0ACOR-CODSUBES ,
            :V0ACOR-DTINIVIG ,
            :V0ACOR-DTTERVIG ,
            :V0ACOR-PCPARCOR ,
            :V0ACOR-PCCOMCOR ,
            :V0ACOR-TIPCOM ,
            :V0ACOR-INDCRT ,
            :V0ACOR-COD-EMPRESA:VIND-COD-EMP,
            CURRENT TIMESTAMP ,
            :V0ACOR-COD-USUARIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCORRET VALUES ({FieldThreatment(this.V0ACOR_NUM_APOL)} , {FieldThreatment(this.V0ACOR_RAMOFR)} , {FieldThreatment(this.V0ACOR_MODALIFR)} , {FieldThreatment(this.V0ACOR_CODCORR)} , {FieldThreatment(this.V0ACOR_CODSUBES)} , {FieldThreatment(this.V0ACOR_DTINIVIG)} , {FieldThreatment(this.V0ACOR_DTTERVIG)} , {FieldThreatment(this.V0ACOR_PCPARCOR)} , {FieldThreatment(this.V0ACOR_PCCOMCOR)} , {FieldThreatment(this.V0ACOR_TIPCOM)} , {FieldThreatment(this.V0ACOR_INDCRT)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0ACOR_COD_EMPRESA))}, CURRENT TIMESTAMP , {FieldThreatment(this.V0ACOR_COD_USUARIO)})";

            return query;
        }
        public string V0ACOR_NUM_APOL { get; set; }
        public string V0ACOR_RAMOFR { get; set; }
        public string V0ACOR_MODALIFR { get; set; }
        public string V0ACOR_CODCORR { get; set; }
        public string V0ACOR_CODSUBES { get; set; }
        public string V0ACOR_DTINIVIG { get; set; }
        public string V0ACOR_DTTERVIG { get; set; }
        public string V0ACOR_PCPARCOR { get; set; }
        public string V0ACOR_PCCOMCOR { get; set; }
        public string V0ACOR_TIPCOM { get; set; }
        public string V0ACOR_INDCRT { get; set; }
        public string V0ACOR_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0ACOR_COD_USUARIO { get; set; }

        public static void Execute(R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1 r3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1)
        {
            var ths = r3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}