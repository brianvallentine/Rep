using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0573_00_LER_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R0573_00_LER_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.PRM_TARIFARIO_IX
            INTO :PARCELAS-PRM-TARIFARIO-IX
            FROM SEGUROS.PARCELAS A
            WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND A.NUM_PARCELA = :PARCELAS-NUM-PARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.PRM_TARIFARIO_IX
											FROM SEGUROS.PARCELAS A
											WHERE A.NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND A.NUM_PARCELA = '{this.PARCELAS_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string PARCELAS_PRM_TARIFARIO_IX { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static R0573_00_LER_PARCELA_DB_SELECT_1_Query1 Execute(R0573_00_LER_PARCELA_DB_SELECT_1_Query1 r0573_00_LER_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r0573_00_LER_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0573_00_LER_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0573_00_LER_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}