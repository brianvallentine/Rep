using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1 : QueryBasis<R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_TERMO,
            COD_SUBGRUPO,
            DATA_ADESAO,
            PERI_PAGAMENTO,
            MODALIDADE_CAPITAL
            INTO
            :NUM-TERMO,
            :COD-SUBGRUPO,
            :DATA-ADESAO,
            :PERI-PAGTO,
            :MODALIDADE-CAPITAL
            FROM
            SEGUROS.V1TERMOADESAO
            WHERE
            COD_SUBGRUPO = :V1SOLF-COD-SUBG AND
            NUM_APOLICE = :V1SOLF-NUM-APOL AND
            SITUACAO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_TERMO
							,
											COD_SUBGRUPO
							,
											DATA_ADESAO
							,
											PERI_PAGAMENTO
							,
											MODALIDADE_CAPITAL
											FROM
											SEGUROS.V1TERMOADESAO
											WHERE
											COD_SUBGRUPO = '{this.V1SOLF_COD_SUBG}' AND
											NUM_APOLICE = '{this.V1SOLF_NUM_APOL}' AND
											SITUACAO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string NUM_TERMO { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string DATA_ADESAO { get; set; }
        public string PERI_PAGTO { get; set; }
        public string MODALIDADE_CAPITAL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }

        public static R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1 Execute(R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1 r0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1)
        {
            var ths = r0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_TERMO = result[i++].Value?.ToString();
            dta.COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.DATA_ADESAO = result[i++].Value?.ToString();
            dta.PERI_PAGTO = result[i++].Value?.ToString();
            dta.MODALIDADE_CAPITAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}