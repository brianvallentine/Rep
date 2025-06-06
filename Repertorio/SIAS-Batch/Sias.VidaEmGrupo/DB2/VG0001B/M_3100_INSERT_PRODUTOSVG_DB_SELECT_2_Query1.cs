using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1 : QueryBasis<M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_GARANTIA
            INTO :VGCOBTER-COD-GARANTIA
            FROM SEGUROS.VG_COBER_TERMO
            WHERE NUM_PROPOSTA_SIVPF = :VGCOMTRO-NUM-PROPOSTA-SIVPF
            AND COD_GARANTIA = 15
            AND DTH_FIM_VIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_GARANTIA
											FROM SEGUROS.VG_COBER_TERMO
											WHERE NUM_PROPOSTA_SIVPF = '{this.VGCOMTRO_NUM_PROPOSTA_SIVPF}'
											AND COD_GARANTIA = 15
											AND DTH_FIM_VIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string VGCOBTER_COD_GARANTIA { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }

        public static M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1 Execute(M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1 m_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1)
        {
            var ths = m_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1();
            var i = 0;
            dta.VGCOBTER_COD_GARANTIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}