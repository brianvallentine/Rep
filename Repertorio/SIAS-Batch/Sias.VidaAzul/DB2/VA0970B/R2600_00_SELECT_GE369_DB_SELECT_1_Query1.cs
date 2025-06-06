using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R2600_00_SELECT_GE369_DB_SELECT_1_Query1 : QueryBasis<R2600_00_SELECT_GE369_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_BANCO ,
            A.COD_AGENCIA ,
            A.NUM_OPERACAO_CONTA ,
            A.NUM_CONTA
            INTO :OD009-COD-BANCO ,
            :OD009-COD-AGENCIA ,
            :OD009-NUM-OPERACAO-CONTA,
            :OD009-NUM-CONTA
            FROM ODS.OD_PESS_CONTA_BANC A,
            SEGUROS.SI_PESS_SINISTRO B,
            SEGUROS.GE_LEG_PESS_EVENTO C
            WHERE B.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND B.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND B.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO
            AND C.NUM_PESSOA = A.NUM_PESSOA
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_BANCO 
							,
											A.COD_AGENCIA 
							,
											A.NUM_OPERACAO_CONTA 
							,
											A.NUM_CONTA
											FROM ODS.OD_PESS_CONTA_BANC A
							,
											SEGUROS.SI_PESS_SINISTRO B
							,
											SEGUROS.GE_LEG_PESS_EVENTO C
											WHERE B.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND B.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO
											AND C.NUM_PESSOA = A.NUM_PESSOA
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R2600_00_SELECT_GE369_DB_SELECT_1_Query1 Execute(R2600_00_SELECT_GE369_DB_SELECT_1_Query1 r2600_00_SELECT_GE369_DB_SELECT_1_Query1)
        {
            var ths = r2600_00_SELECT_GE369_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2600_00_SELECT_GE369_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2600_00_SELECT_GE369_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD009_COD_BANCO = result[i++].Value?.ToString();
            dta.OD009_COD_AGENCIA = result[i++].Value?.ToString();
            dta.OD009_NUM_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}