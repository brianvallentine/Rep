using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0180_00_SELECT_GE403_DB_SELECT_1_Query1 : QueryBasis<R0180_00_SELECT_GE403_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NUM_RCAP
            ,C.VAL_RCAP
            ,C.DATA_CADASTRAMENTO
            ,C.SIT_REGISTRO
            ,C.COD_OPERACAO
            ,C.NUM_TITULO
            ,D.BCO_AVISO
            ,D.AGE_AVISO
            ,D.NUM_AVISO_CREDITO
            INTO :RCAPS-NUM-RCAP
            ,:RCAPS-VAL-RCAP
            ,:RCAPS-DATA-CADASTRAMENTO
            ,:RCAPS-SIT-REGISTRO
            ,:RCAPS-COD-OPERACAO
            ,:RCAPS-NUM-TITULO
            ,:RCAPCOMP-BCO-AVISO
            ,:RCAPCOMP-AGE-AVISO
            ,:RCAPCOMP-NUM-AVISO-CREDITO
            FROM SEGUROS.CONVERSAO_SICOB A
            ,SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
            ,SEGUROS.RCAPS C
            ,SEGUROS.RCAP_COMPLEMENTAR D
            WHERE A.NUM_SICOB = :CONVERSI-NUM-SICOB
            AND B.NUM_PROPOSTA = A.NUM_PROPOSTA_SIVPF
            AND B.COD_SITUACAO = 'F'
            AND B.NUM_PARCELA = 1
            AND C.NUM_CERTIFICADO = A.NUM_PROPOSTA_SIVPF
            AND D.COD_FONTE = C.COD_FONTE
            AND D.NUM_RCAP = C.NUM_RCAP
            AND D.SIT_REGISTRO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.NUM_RCAP
											,C.VAL_RCAP
											,C.DATA_CADASTRAMENTO
											,C.SIT_REGISTRO
											,C.COD_OPERACAO
											,C.NUM_TITULO
											,D.BCO_AVISO
											,D.AGE_AVISO
											,D.NUM_AVISO_CREDITO
											FROM SEGUROS.CONVERSAO_SICOB A
											,SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
											,SEGUROS.RCAPS C
											,SEGUROS.RCAP_COMPLEMENTAR D
											WHERE A.NUM_SICOB = '{this.CONVERSI_NUM_SICOB}'
											AND B.NUM_PROPOSTA = A.NUM_PROPOSTA_SIVPF
											AND B.COD_SITUACAO = 'F'
											AND B.NUM_PARCELA = 1
											AND C.NUM_CERTIFICADO = A.NUM_PROPOSTA_SIVPF
											AND D.COD_FONTE = C.COD_FONTE
											AND D.NUM_RCAP = C.NUM_RCAP
											AND D.SIT_REGISTRO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string CONVERSI_NUM_SICOB { get; set; }

        public static R0180_00_SELECT_GE403_DB_SELECT_1_Query1 Execute(R0180_00_SELECT_GE403_DB_SELECT_1_Query1 r0180_00_SELECT_GE403_DB_SELECT_1_Query1)
        {
            var ths = r0180_00_SELECT_GE403_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0180_00_SELECT_GE403_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0180_00_SELECT_GE403_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}