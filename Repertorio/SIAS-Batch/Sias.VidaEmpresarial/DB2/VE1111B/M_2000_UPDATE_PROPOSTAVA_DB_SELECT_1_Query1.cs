using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE1111B
{
    public class M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO
            :VGPROSIA-COD-PRODUTO
            FROM SEGUROS.VG_PRODUTO_SIAS
            WHERE NUM_APOLICE = :VGPROSIA-NUM-APOLICE
            AND NUM_PERIODO_PAG = :VGPROSIA-NUM-PERIODO-PAG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.VG_PRODUTO_SIAS
											WHERE NUM_APOLICE = '{this.VGPROSIA_NUM_APOLICE}'
											AND NUM_PERIODO_PAG = '{this.VGPROSIA_NUM_PERIODO_PAG}'
											WITH UR";

            return query;
        }
        public string VGPROSIA_COD_PRODUTO { get; set; }
        public string VGPROSIA_NUM_PERIODO_PAG { get; set; }
        public string VGPROSIA_NUM_APOLICE { get; set; }

        public static M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1 Execute(M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1 m_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = m_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGPROSIA_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}