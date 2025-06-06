using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_APOLICE
            INTO :V1NAES-SEQ-APOL
            FROM SEGUROS.V1NUMERO_AES
            WHERE COD_ORGAO = :WH-JV1-COD-ORGAO
            AND COD_RAMO = :V0BILH-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_APOLICE
											FROM SEGUROS.V1NUMERO_AES
											WHERE COD_ORGAO = '{this.WH_JV1_COD_ORGAO}'
											AND COD_RAMO = '{this.V0BILH_RAMO}'";

            return query;
        }
        public string V1NAES_SEQ_APOL { get; set; }
        public string WH_JV1_COD_ORGAO { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1NAES_SEQ_APOL = result[i++].Value?.ToString();
            return dta;
        }

    }
}