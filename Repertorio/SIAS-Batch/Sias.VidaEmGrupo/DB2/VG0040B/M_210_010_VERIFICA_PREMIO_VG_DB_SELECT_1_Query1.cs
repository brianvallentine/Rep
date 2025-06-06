using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0040B
{
    public class M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1 : QueryBasis<M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            MAX(DTTERVIG)
            INTO
            :VGDATA-TERVIGENCIA
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :MNUM-CERTIFICADO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											MAX(DTTERVIG)
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.MNUM_CERTIFICADO}'";

            return query;
        }
        public string VGDATA_TERVIGENCIA { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1 Execute(M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1 m_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1)
        {
            var ths = m_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGDATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}