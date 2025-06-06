using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0112B
{
    public class R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_CERTIFICADO
            , B.COD_PRODUTO
            , B.NUM_APOLICE
            , B.COD_SUBGRUPO
            INTO :PROPOVA-NUM-CERTIFICADO
            , :PROPOVA-COD-PRODUTO
            , :PROPOVA-NUM-APOLICE
            , :PROPOVA-COD-SUBGRUPO
            FROM SEGUROS.COBER_HIST_VIDAZUL A
            , SEGUROS.PROPOSTAS_VA B
            WHERE A.NUM_TITULO = :COBHISVI-NUM-TITULO
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.NUM_CERTIFICADO
											, B.COD_PRODUTO
											, B.NUM_APOLICE
											, B.COD_SUBGRUPO
											FROM SEGUROS.COBER_HIST_VIDAZUL A
											, SEGUROS.PROPOSTAS_VA B
											WHERE A.NUM_TITULO = '{this.COBHISVI_NUM_TITULO}'
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }

        public static R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1 r0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}