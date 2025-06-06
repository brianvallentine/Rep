using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1 : QueryBasis<R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MODALIDADE
            ,RAMO_EMISSOR
            ,COD_PRODUTO
            INTO :APOLICES-COD-MODALIDADE
            ,:APOLICES-RAMO-EMISSOR
            ,:APOLICES-COD-PRODUTO
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MODALIDADE
											,RAMO_EMISSOR
											,COD_PRODUTO
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1 Execute(R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1 r110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1)
        {
            var ths = r110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1();
            var i = 0;
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}