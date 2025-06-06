using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 : QueryBasis<R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-COUNT
            FROM SEGUROS.PROPOSTAS_VA A,
            SEGUROS.SINISTRO_MESTRE B,
            SEGUROS.CLIENTES C
            WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.COD_CLIENTE = C.COD_CLIENTE
            AND C.CGCCPF = :DCLPESSOA-FISICA.CPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.PROPOSTAS_VA A
							,
											SEGUROS.SINISTRO_MESTRE B
							,
											SEGUROS.CLIENTES C
											WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.COD_CLIENTE = C.COD_CLIENTE
											AND C.CGCCPF = '{this.CPF}'";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string CPF { get; set; }

        public static R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 Execute(R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1)
        {
            var ths = r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}