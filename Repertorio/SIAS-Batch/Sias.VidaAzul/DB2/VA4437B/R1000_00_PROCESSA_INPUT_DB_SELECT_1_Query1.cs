using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :WS-DUPLICADO
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND COD_RELATORIO = :RELATORI-COD-RELATORIO
            AND COD_OPERACAO = :RELATORI-COD-OPERACAO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND TIMESTAMP < :RELATORI-TIMESTAMP
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND COD_RELATORIO = '{this.RELATORI_COD_RELATORIO}'
											AND COD_OPERACAO = '{this.RELATORI_COD_OPERACAO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND TIMESTAMP < '{this.RELATORI_TIMESTAMP}'";

            return query;
        }
        public string WS_DUPLICADO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_TIMESTAMP { get; set; }

        public static R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DUPLICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}