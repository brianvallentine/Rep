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
    public class R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1 : QueryBasis<R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-COUNT
            FROM SEGUROS.PROPOSTAS_VA A,
            SEGUROS.ERROS_PROP_VIDAZUL B,
            SEGUROS.CLIENTES C
            WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.SIT_REGISTRO = '2'
            AND B.COD_ERRO IN (1802,1807,1811,
            1005,1006,1862)
            AND A.COD_CLIENTE = C.COD_CLIENTE
            AND C.CGCCPF = :DCLPESSOA-FISICA.CPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.PROPOSTAS_VA A
							,
											SEGUROS.ERROS_PROP_VIDAZUL B
							,
											SEGUROS.CLIENTES C
											WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.SIT_REGISTRO = '2'
											AND B.COD_ERRO IN (1802
							,1807
							,1811
							,
											1005
							,1006
							,1862)
											AND A.COD_CLIENTE = C.COD_CLIENTE
											AND C.CGCCPF = '{this.CPF}'
											WITH UR";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string CPF { get; set; }

        public static R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1 Execute(R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1 r2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1)
        {
            var ths = r2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}