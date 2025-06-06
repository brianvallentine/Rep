using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_CLIENTE,
            A.NUM_CERTIFICADO,
            A.DAC_CERTIFICADO
            INTO :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-NUM-CERTIFICADO,
            :SEGURVGA-DAC-CERTIFICADO
            FROM SEGUROS.SEGURADOS_VGAP A,
            SEGUROS.CLIENTES B
            WHERE A.NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND A.COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO
            AND A.COD_CLIENTE = B.COD_CLIENTE
            AND B.CGCCPF = :CLIENTES-CGCCPF
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_CLIENTE
							,
											A.NUM_CERTIFICADO
							,
											A.DAC_CERTIFICADO
											FROM SEGUROS.SEGURADOS_VGAP A
							,
											SEGUROS.CLIENTES B
											WHERE A.NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND A.COD_SUBGRUPO = '{this.SEGURVGA_COD_SUBGRUPO}'
											AND A.COD_CLIENTE = B.COD_CLIENTE
											AND B.CGCCPF = '{this.CLIENTES_CGCCPF}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_DAC_CERTIFICADO { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1 Execute(R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1 r8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_DAC_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}