using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202B
{
    public class R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1 : QueryBasis<R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT H.NUM_APOL_SINISTRO ,
            P.VAL_INDENIZACAO ,
            P.VAL_SALDO_DEVEDOR ,
            P.VAL_ACORRIGIR ,
            P.QTD_PRE_ARECUPERAR ,
            P.VAL_PREMIO ,
            H.DATA_MOVIMENTO
            INTO :SINISHIS-NUM-APOL-SINISTRO ,
            :SINIPLAN-VAL-INDENIZACAO ,
            :SINIPLAN-VAL-SALDO-DEVEDOR ,
            :SINIPLAN-VAL-ACORRIGIR ,
            :SINIPLAN-QTD-PRE-ARECUPERAR ,
            :SINIPLAN-VAL-PREMIO ,
            :SINISHIS-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO H ,
            SEGUROS.SINI_PLANHABIT01 P ,
            SEGUROS.GE_SIS_FUNCAO_OPER O
            WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO <> 1004
            AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND P.OCORHIST = H.OCORR_HISTORICO
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IDE_SISTEMA = 'SI'
            AND O.COD_FUNCAO = 2
            AND O.NUM_FATOR = 1
            AND NOT EXISTS
            (SELECT X.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO X
            WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND X.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND ( X.NOM_PROGRAMA <> 'SI0170B'
            OR X.NOM_PROGRAMA IS NULL)
            AND X.COD_OPERACAO =
            (SELECT O.COD_OPERACAO
            FROM SEGUROS.GE_SIS_FUNCAO_OPER O
            WHERE O.IDE_SISTEMA = 'SI'
            AND O.COD_FUNCAO = 2
            AND O.COD_OPERACAO <> 29
            AND O.NUM_FATOR = -1) )
            AND ( H.NOM_PROGRAMA <> 'SI0170B'
            OR H.NOM_PROGRAMA IS NULL)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT H.NUM_APOL_SINISTRO 
							,
											P.VAL_INDENIZACAO 
							,
											P.VAL_SALDO_DEVEDOR 
							,
											P.VAL_ACORRIGIR 
							,
											P.QTD_PRE_ARECUPERAR 
							,
											P.VAL_PREMIO 
							,
											H.DATA_MOVIMENTO
											FROM SEGUROS.SINISTRO_HISTORICO H 
							,
											SEGUROS.SINI_PLANHABIT01 P 
							,
											SEGUROS.GE_SIS_FUNCAO_OPER O
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND H.COD_OPERACAO <> 1004
											AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND P.OCORHIST = H.OCORR_HISTORICO
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IDE_SISTEMA = 'SI'
											AND O.COD_FUNCAO = 2
											AND O.NUM_FATOR = 1
											AND NOT EXISTS
											(SELECT X.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO X
											WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND X.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND ( X.NOM_PROGRAMA <> 'SI0170B'
											OR X.NOM_PROGRAMA IS NULL)
											AND X.COD_OPERACAO =
											(SELECT O.COD_OPERACAO
											FROM SEGUROS.GE_SIS_FUNCAO_OPER O
											WHERE O.IDE_SISTEMA = 'SI'
											AND O.COD_FUNCAO = 2
											AND O.COD_OPERACAO <> 29
											AND O.NUM_FATOR = -1) )
											AND ( H.NOM_PROGRAMA <> 'SI0170B'
											OR H.NOM_PROGRAMA IS NULL)
											WITH UR";

            return query;
        }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINIPLAN_VAL_INDENIZACAO { get; set; }
        public string SINIPLAN_VAL_SALDO_DEVEDOR { get; set; }
        public string SINIPLAN_VAL_ACORRIGIR { get; set; }
        public string SINIPLAN_QTD_PRE_ARECUPERAR { get; set; }
        public string SINIPLAN_VAL_PREMIO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1 Execute(R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1 r510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1)
        {
            var ths = r510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_INDENIZACAO = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_SALDO_DEVEDOR = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_ACORRIGIR = result[i++].Value?.ToString();
            dta.SINIPLAN_QTD_PRE_ARECUPERAR = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_PREMIO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}