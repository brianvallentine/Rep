using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1 : QueryBasis<R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VAL_TITULO),0)
            INTO :MOVIMCOB-VAL-TITULO
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE TIPO_MOVIMENTO = '7'
            AND SIT_REGISTRO = ' '
            AND COD_BANCO = :MOVIMCOB-COD-BANCO
            AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA
            AND NUM_AVISO = :MOVIMCOB-NUM-AVISO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VAL_TITULO)
							,0)
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE TIPO_MOVIMENTO = '7'
											AND SIT_REGISTRO = ' '
											AND COD_BANCO = '{this.MOVIMCOB_COD_BANCO}'
											AND COD_AGENCIA = '{this.MOVIMCOB_COD_AGENCIA}'
											AND NUM_AVISO = '{this.MOVIMCOB_NUM_AVISO}'";

            return query;
        }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }

        public static R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1 Execute(R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1 r1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1)
        {
            var ths = r1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOVIMCOB_VAL_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}