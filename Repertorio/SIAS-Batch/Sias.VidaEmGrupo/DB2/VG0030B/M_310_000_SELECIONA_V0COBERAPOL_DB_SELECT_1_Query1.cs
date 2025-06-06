using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE (MAX(OCORHIST),0) + 1
            INTO :MAX-OCORR-HIST
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :VGNUM-APOLICE
            AND NUM_ITEM = :VGNUM-ITEM
            AND COD_COBERTURA = :VGCOD-COBERTURA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE (MAX(OCORHIST)
							,0) + 1
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.VGNUM_APOLICE}'
											AND NUM_ITEM = '{this.VGNUM_ITEM}'
											AND COD_COBERTURA = '{this.VGCOD_COBERTURA}'
											WITH UR";

            return query;
        }
        public string MAX_OCORR_HIST { get; set; }
        public string VGCOD_COBERTURA { get; set; }
        public string VGNUM_APOLICE { get; set; }
        public string VGNUM_ITEM { get; set; }

        public static M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1 Execute(M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1 m_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = m_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.MAX_OCORR_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}