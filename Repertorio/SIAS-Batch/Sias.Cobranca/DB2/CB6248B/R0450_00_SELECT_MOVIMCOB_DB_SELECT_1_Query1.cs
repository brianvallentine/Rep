using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6248B
{
    public class R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 : QueryBasis<R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :MOVIMCOB-SIT-REGISTRO
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE COD_BANCO =
            :MOVIMCOB-COD-BANCO
            AND COD_AGENCIA =
            :MOVIMCOB-COD-AGENCIA
            AND NUM_AVISO =
            :MOVIMCOB-NUM-AVISO
            AND NUM_TITULO =
            :MOVIMCOB-NUM-TITULO
            AND NUM_APOLICE =
            :MOVIMCOB-NUM-APOLICE
            AND NUM_ENDOSSO =
            :MOVIMCOB-NUM-ENDOSSO
            AND NUM_PARCELA =
            :MOVIMCOB-NUM-PARCELA
            AND NUM_NOSSO_TITULO =
            :MOVIMCOB-NUM-NOSSO-TITULO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE COD_BANCO =
											'{this.MOVIMCOB_COD_BANCO}'
											AND COD_AGENCIA =
											'{this.MOVIMCOB_COD_AGENCIA}'
											AND NUM_AVISO =
											'{this.MOVIMCOB_NUM_AVISO}'
											AND NUM_TITULO =
											'{this.MOVIMCOB_NUM_TITULO}'
											AND NUM_APOLICE =
											'{this.MOVIMCOB_NUM_APOLICE}'
											AND NUM_ENDOSSO =
											'{this.MOVIMCOB_NUM_ENDOSSO}'
											AND NUM_PARCELA =
											'{this.MOVIMCOB_NUM_PARCELA}'
											AND NUM_NOSSO_TITULO =
											'{this.MOVIMCOB_NUM_NOSSO_TITULO}'
											WITH UR";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }

        public static R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 Execute(R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 r0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1)
        {
            var ths = r0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}