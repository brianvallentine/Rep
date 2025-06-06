using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105S
{
    public class R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1 : QueryBasis<R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO,
            A.COD_PLANO,
            A.COD_PRODUTO,
            A.STA_ACOPLADO
            INTO :VG135-NUM-CERTIFICADO
            , :VG135-COD-PLANO
            , :VG135-COD-PRODUTO
            , :VG135-STA-ACOPLADO
            FROM SEGUROS.VG_ACOPLADO A
            , SEGUROS.VG_ACOPLADO_TITULO B
            WHERE B.NUM_SERIE = :LK-NUM-SERIE
            AND B.NUM_TITULO = :LK-NUM-TITULO
            AND B.COD_PLANO = :VG135-COD-PLANO
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND B.COD_PLANO = A.COD_PLANO
            AND B.COD_PRODUTO = A.COD_PRODUTO
            AND B.IDE_SISTEMA = A.IDE_SISTEMA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
							,
											A.COD_PLANO
							,
											A.COD_PRODUTO
							,
											A.STA_ACOPLADO
											FROM SEGUROS.VG_ACOPLADO A
											, SEGUROS.VG_ACOPLADO_TITULO B
											WHERE B.NUM_SERIE = '{this.LK_NUM_SERIE}'
											AND B.NUM_TITULO = '{this.LK_NUM_TITULO}'
											AND B.COD_PLANO = '{this.VG135_COD_PLANO}'
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND B.COD_PLANO = A.COD_PLANO
											AND B.COD_PRODUTO = A.COD_PRODUTO
											AND B.IDE_SISTEMA = A.IDE_SISTEMA
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string VG135_NUM_CERTIFICADO { get; set; }
        public string VG135_COD_PLANO { get; set; }
        public string VG135_COD_PRODUTO { get; set; }
        public string VG135_STA_ACOPLADO { get; set; }
        public string LK_NUM_TITULO { get; set; }
        public string LK_NUM_SERIE { get; set; }

        public static R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1 Execute(R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1 r0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1)
        {
            var ths = r0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG135_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG135_COD_PLANO = result[i++].Value?.ToString();
            dta.VG135_COD_PRODUTO = result[i++].Value?.ToString();
            dta.VG135_STA_ACOPLADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}