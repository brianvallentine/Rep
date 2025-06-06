using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1 : QueryBasis<R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_PAGAMENTO
            INTO :PRODUVG-PERI-PAGAMENTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE
            AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_PAGAMENTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.PRODUVG_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PRODUVG_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_NUM_APOLICE { get; set; }

        public static R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1 Execute(R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1 r3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1)
        {
            var ths = r3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}