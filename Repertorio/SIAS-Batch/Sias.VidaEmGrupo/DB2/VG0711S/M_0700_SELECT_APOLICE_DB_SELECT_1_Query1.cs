using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_0700_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_0700_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_MODALIDADE,
            A.RAMO_EMISSOR,
            B.PCT_IOCC_RAMO
            INTO :WS-MODALIDA,
            :WS-RAMO,
            :RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.APOLICES A,
            SEGUROS.RAMO_COMPLEMENTAR B
            WHERE A.NUM_APOLICE = :WS-NUM-APOLICE
            AND A.RAMO_EMISSOR = B.RAMO_EMISSOR
            AND B.DATA_INIVIGENCIA <= :WS-SISTEMA-DTMOVABE
            AND B.DATA_TERVIGENCIA >= :WS-SISTEMA-DTMOVABE
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_MODALIDADE
							,
											A.RAMO_EMISSOR
							,
											B.PCT_IOCC_RAMO
											FROM SEGUROS.APOLICES A
							,
											SEGUROS.RAMO_COMPLEMENTAR B
											WHERE A.NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND A.RAMO_EMISSOR = B.RAMO_EMISSOR
											AND B.DATA_INIVIGENCIA <= '{this.WS_SISTEMA_DTMOVABE}'
											AND B.DATA_TERVIGENCIA >= '{this.WS_SISTEMA_DTMOVABE}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string WS_MODALIDA { get; set; }
        public string WS_RAMO { get; set; }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string WS_SISTEMA_DTMOVABE { get; set; }
        public string WS_NUM_APOLICE { get; set; }

        public static M_0700_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(M_0700_SELECT_APOLICE_DB_SELECT_1_Query1 m_0700_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_0700_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0700_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0700_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_MODALIDA = result[i++].Value?.ToString();
            dta.WS_RAMO = result[i++].Value?.ToString();
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}