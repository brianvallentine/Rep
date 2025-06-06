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
    public class M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1 : QueryBasis<M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IMPMORACID, 0)
            , VALUE(PRMAP, 0)
            , VALUE(QUANT_VIDAS, 0)
            INTO :WIMP-MORACID-ATU
            , :WPRM-AP-ATU
            , :WQUANT-VIDAS
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :WNUM-CERTIFICADO
            AND DATA_INIVIGENCIA <= :MDATA-OPERACAO
            AND DATA_TERVIGENCIA >= :MDATA-OPERACAO
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(IMPMORACID
							, 0)
											, VALUE(PRMAP
							, 0)
											, VALUE(QUANT_VIDAS
							, 0)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.WNUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA <= '{this.MDATA_OPERACAO}'
											AND DATA_TERVIGENCIA >= '{this.MDATA_OPERACAO}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string WIMP_MORACID_ATU { get; set; }
        public string WPRM_AP_ATU { get; set; }
        public string WQUANT_VIDAS { get; set; }
        public string WNUM_CERTIFICADO { get; set; }
        public string MDATA_OPERACAO { get; set; }

        public static M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1 Execute(M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1 m_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1)
        {
            var ths = m_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WIMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.WPRM_AP_ATU = result[i++].Value?.ToString();
            dta.WQUANT_VIDAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}