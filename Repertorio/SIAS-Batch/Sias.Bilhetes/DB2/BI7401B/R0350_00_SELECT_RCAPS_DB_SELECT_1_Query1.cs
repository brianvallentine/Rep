using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.SIT_REGISTRO
            ,A.COD_OPERACAO
            ,B.COD_FONTE
            ,B.NUM_RCAP
            ,B.NUM_RCAP_COMPLEMEN
            ,B.COD_OPERACAO
            ,B.BCO_AVISO
            ,B.AGE_AVISO
            ,B.NUM_AVISO_CREDITO
            ,B.VAL_RCAP
            ,B.DATA_RCAP
            ,B.DATA_CADASTRAMENTO
            ,B.SIT_CONTABIL
            ,B.COD_EMPRESA
            INTO :RCAPS-SIT-REGISTRO
            ,:RCAPS-COD-OPERACAO
            ,:RCAPCOMP-COD-FONTE
            ,:RCAPCOMP-NUM-RCAP
            ,:RCAPCOMP-NUM-RCAP-COMPLEMEN
            ,:RCAPCOMP-COD-OPERACAO
            ,:RCAPCOMP-BCO-AVISO
            ,:RCAPCOMP-AGE-AVISO
            ,:RCAPCOMP-NUM-AVISO-CREDITO
            ,:RCAPCOMP-VAL-RCAP
            ,:RCAPCOMP-DATA-RCAP
            ,:RCAPCOMP-DATA-CADASTRAMENTO
            ,:RCAPCOMP-SIT-CONTABIL
            ,:RCAPCOMP-COD-EMPRESA:VIND-NULL01
            FROM SEGUROS.RCAPS A
            ,SEGUROS.RCAP_COMPLEMENTAR B
            WHERE A.NUM_TITULO = :BILHETE-NUM-BILHETE
            AND B.NUM_RCAP = A.NUM_RCAP
            AND B.COD_FONTE = A.COD_FONTE
            AND B.SIT_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.SIT_REGISTRO
											,A.COD_OPERACAO
											,B.COD_FONTE
											,B.NUM_RCAP
											,B.NUM_RCAP_COMPLEMEN
											,B.COD_OPERACAO
											,B.BCO_AVISO
											,B.AGE_AVISO
											,B.NUM_AVISO_CREDITO
											,B.VAL_RCAP
											,B.DATA_RCAP
											,B.DATA_CADASTRAMENTO
											,B.SIT_CONTABIL
											,B.COD_EMPRESA
											FROM SEGUROS.RCAPS A
											,SEGUROS.RCAP_COMPLEMENTAR B
											WHERE A.NUM_TITULO = '{this.BILHETE_NUM_BILHETE}'
											AND B.NUM_RCAP = A.NUM_RCAP
											AND B.COD_FONTE = A.COD_FONTE
											AND B.SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string RCAPCOMP_COD_OPERACAO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPCOMP_DATA_CADASTRAMENTO { get; set; }
        public string RCAPCOMP_SIT_CONTABIL { get; set; }
        public string RCAPCOMP_COD_EMPRESA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0350_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPCOMP_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP_COMPLEMEN = result[i++].Value?.ToString();
            dta.RCAPCOMP_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.RCAPCOMP_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPCOMP_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.RCAPCOMP_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.RCAPCOMP_COD_EMPRESA) ? "-1" : "0";
            return dta;
        }

    }
}