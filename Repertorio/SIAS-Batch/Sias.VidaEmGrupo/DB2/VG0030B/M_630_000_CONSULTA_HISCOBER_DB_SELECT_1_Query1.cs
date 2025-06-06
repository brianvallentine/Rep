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
    public class M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1 : QueryBasis<M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(PRMVG, 0),
            VALUE(PRMAP, 0),
            VALUE(IMP_MORNATU, 0),
            VALUE(IMPMORACID, 0)
            INTO :MPRM-VG-ATU,
            :MPRM-AP-ATU,
            :MIMP-MORNATU-ATU,
            :MIMP-MORACID-ATU
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            ORDER BY OCORR_HISTORICO DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(PRMVG
							, 0)
							,
											VALUE(PRMAP
							, 0)
							,
											VALUE(IMP_MORNATU
							, 0)
							,
											VALUE(IMPMORACID
							, 0)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											ORDER BY OCORR_HISTORICO DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string MPRM_VG_ATU { get; set; }
        public string MPRM_AP_ATU { get; set; }
        public string MIMP_MORNATU_ATU { get; set; }
        public string MIMP_MORACID_ATU { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1 Execute(M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1 m_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1)
        {
            var ths = m_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.MPRM_VG_ATU = result[i++].Value?.ToString();
            dta.MPRM_AP_ATU = result[i++].Value?.ToString();
            dta.MIMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MIMP_MORACID_ATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}