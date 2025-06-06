using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2118S
{
    public class R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-COUNT
            FROM SEGUROS.PARCELAS A,
            SEGUROS.PARCELA_HISTORICO B
            WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE
            AND A.NUM_ENDOSSO = 0
            AND A.SIT_REGISTRO = '0'
            AND B.COD_OPERACAO = 101
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.PARCELAS A
							,
											SEGUROS.PARCELA_HISTORICO B
											WHERE A.NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = 0
											AND A.SIT_REGISTRO = '0'
											AND B.COD_OPERACAO = 101
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1 Execute(R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1 r2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}