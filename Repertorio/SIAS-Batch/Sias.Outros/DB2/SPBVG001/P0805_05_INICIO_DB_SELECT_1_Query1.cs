using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0805_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0805_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(C.ORIG_PRODU, ' ' )
            INTO :WS-ORIG-PRODUTO
            FROM SEGUROS.VG_SOLICITA_FATURA A,
            SEGUROS.PROPOSTAS_VA B,
            SEGUROS.PRODUTOS_VG C,
            SEGUROS.CONVERSAO_SICOB D
            WHERE B.NUM_CERTIFICADO = :VGSOLFAT-NUM-TITULO
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND A.NUM_APOLICE = C.NUM_APOLICE
            AND A.COD_SUBGRUPO = C.COD_SUBGRUPO
            AND A.NUM_APOLICE = D.NUM_SICOB
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(C.ORIG_PRODU
							, ' ' )
											FROM SEGUROS.VG_SOLICITA_FATURA A
							,
											SEGUROS.PROPOSTAS_VA B
							,
											SEGUROS.PRODUTOS_VG C
							,
											SEGUROS.CONVERSAO_SICOB D
											WHERE B.NUM_CERTIFICADO = '{this.VGSOLFAT_NUM_TITULO}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND A.NUM_APOLICE = C.NUM_APOLICE
											AND A.COD_SUBGRUPO = C.COD_SUBGRUPO
											AND A.NUM_APOLICE = D.NUM_SICOB
											WITH UR";

            return query;
        }
        public string WS_ORIG_PRODUTO { get; set; }
        public string VGSOLFAT_NUM_TITULO { get; set; }

        public static P0805_05_INICIO_DB_SELECT_1_Query1 Execute(P0805_05_INICIO_DB_SELECT_1_Query1 p0805_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0805_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0805_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0805_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_ORIG_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}