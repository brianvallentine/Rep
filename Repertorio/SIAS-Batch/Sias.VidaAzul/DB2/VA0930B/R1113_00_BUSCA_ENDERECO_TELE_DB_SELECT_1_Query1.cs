using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1 : QueryBasis<R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :WS-COD-CLIENTE
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string WS_COD_CLIENTE { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1 Execute(R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1 r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1)
        {
            var ths = r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}