using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB142_ACESSA_FATURAS_DB_SELECT_1_Query1 : QueryBasis<DB142_ACESSA_FATURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ENDOSSO,
            DATA_FATURA
            INTO :FATURAS-NUM-ENDOSSO,
            :FATURAS-DATA-FATURA
            FROM SEGUROS.FATURAS
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO
            AND NUM_FATURA = :FATURAS-NUM-FATURA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_ENDOSSO
							,
											DATA_FATURA
											FROM SEGUROS.FATURAS
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.VGSOLFAT_COD_SUBGRUPO}'
											AND NUM_FATURA = '{this.FATURAS_NUM_FATURA}'
											WITH UR";

            return query;
        }
        public string FATURAS_NUM_ENDOSSO { get; set; }
        public string FATURAS_DATA_FATURA { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string FATURAS_NUM_FATURA { get; set; }

        public static DB142_ACESSA_FATURAS_DB_SELECT_1_Query1 Execute(DB142_ACESSA_FATURAS_DB_SELECT_1_Query1 dB142_ACESSA_FATURAS_DB_SELECT_1_Query1)
        {
            var ths = dB142_ACESSA_FATURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB142_ACESSA_FATURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB142_ACESSA_FATURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.FATURAS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.FATURAS_DATA_FATURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}