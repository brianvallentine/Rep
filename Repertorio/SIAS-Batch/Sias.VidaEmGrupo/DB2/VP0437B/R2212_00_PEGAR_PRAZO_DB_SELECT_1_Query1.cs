using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1 : QueryBasis<R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.COD_PLANO, T2.PERI_RENOVACAO
            INTO :PROPOFID-COD-PLANO, :SEGURVGA-PERI-RENOVACAO
            FROM SEGUROS.PROPOSTA_FIDELIZ T1,
            SEGUROS.SEGURADOS_VGAP T2
            WHERE T1.NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF
            AND T2.NUM_CERTIFICADO = T1.NUM_PROPOSTA_SIVPF
            AND T2.TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.COD_PLANO
							, T2.PERI_RENOVACAO
											FROM SEGUROS.PROPOSTA_FIDELIZ T1
							,
											SEGUROS.SEGURADOS_VGAP T2
											WHERE T1.NUM_PROPOSTA_SIVPF = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND T2.NUM_CERTIFICADO = T1.NUM_PROPOSTA_SIVPF
											AND T2.TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string PROPOFID_COD_PLANO { get; set; }
        public string SEGURVGA_PERI_RENOVACAO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1 Execute(R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1 r2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1)
        {
            var ths = r2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_COD_PLANO = result[i++].Value?.ToString();
            dta.SEGURVGA_PERI_RENOVACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}