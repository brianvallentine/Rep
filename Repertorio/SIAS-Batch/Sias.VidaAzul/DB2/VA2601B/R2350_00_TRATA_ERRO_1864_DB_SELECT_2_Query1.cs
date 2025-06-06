using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1 : QueryBasis<R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-COUNT
            FROM SEGUROS.SEGURADOSVGAP_HIST A,
            SEGUROS.SEGURADOS_VGAP B,
            SEGUROS.CLIENTES C,
            SEGUROS.PROPOSTAS_VA D
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND A.NUM_ITEM = B.NUM_ITEM
            AND D.NUM_APOLICE = B.NUM_APOLICE
            AND D.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND D.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND B.TIPO_SEGURADO = '1'
            AND B.COD_CLIENTE = C.COD_CLIENTE
            AND C.CGCCPF = :DCLPESSOA-FISICA.CPF
            AND A.COD_OPERACAO = 403
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.SEGURADOSVGAP_HIST A
							,
											SEGUROS.SEGURADOS_VGAP B
							,
											SEGUROS.CLIENTES C
							,
											SEGUROS.PROPOSTAS_VA D
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND A.NUM_ITEM = B.NUM_ITEM
											AND D.NUM_APOLICE = B.NUM_APOLICE
											AND D.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND D.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND B.TIPO_SEGURADO = '1'
											AND B.COD_CLIENTE = C.COD_CLIENTE
											AND C.CGCCPF = '{this.CPF}'
											AND A.COD_OPERACAO = 403
											WITH UR";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string CPF { get; set; }

        public static R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1 Execute(R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1 r2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1)
        {
            var ths = r2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}