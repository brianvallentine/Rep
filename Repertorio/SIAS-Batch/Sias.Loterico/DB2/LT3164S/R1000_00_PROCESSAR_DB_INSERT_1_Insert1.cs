using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3164S
{
    public class R1000_00_PROCESSAR_DB_INSERT_1_Insert1 : QueryBasis<R1000_00_PROCESSAR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.LT_SOLICITA_PARAM
            (COD_PRODUTO ,
            COD_CLIENTE ,
            COD_PROGRAMA ,
            TIPO_SOLICITACAO,
            DATA_SOLICITACAO,
            COD_USUARIO ,
            DATA_PREV_PROC ,
            SIT_SOLICITACAO ,
            TSTMP_SITUACAO ,
            PARAM_DATE01 ,
            PARAM_DATE02 ,
            PARAM_DATE03 ,
            PARAM_SMINT01 ,
            PARAM_SMINT02 ,
            PARAM_SMINT03 ,
            PARAM_INTG01 ,
            PARAM_INTG02 ,
            PARAM_INTG03 ,
            PARAM_DEC01 ,
            PARAM_DEC02 ,
            PARAM_DEC03 ,
            PARAM_FLOAT01 ,
            PARAM_FLOAT02 ,
            PARAM_CHAR01 ,
            PARAM_CHAR02 ,
            PARAM_CHAR03 ,
            PARAM_CHAR04 ,
            PARAM_CHAR05 ,
            DTH_SOLICITACAO )
            VALUES (:LTSOLPAR-COD-PRODUTO ,
            :LTSOLPAR-COD-CLIENTE ,
            :LTSOLPAR-COD-PROGRAMA ,
            :LTSOLPAR-TIPO-SOLICITACAO ,
            :LTSOLPAR-DATA-SOLICITACAO ,
            :LTSOLPAR-COD-USUARIO ,
            :LTSOLPAR-DATA-PREV-PROC ,
            :LTSOLPAR-SIT-SOLICITACAO ,
            CURRENT TIMESTAMP ,
            :LTSOLPAR-PARAM-DATE01 ,
            :LTSOLPAR-PARAM-DATE02 ,
            :LTSOLPAR-PARAM-DATE03 ,
            :LTSOLPAR-PARAM-SMINT01 ,
            :LTSOLPAR-PARAM-SMINT02 ,
            :LTSOLPAR-PARAM-SMINT03 ,
            :LTSOLPAR-PARAM-INTG01 ,
            :LTSOLPAR-PARAM-INTG02 ,
            :LTSOLPAR-PARAM-INTG03 ,
            :LTSOLPAR-PARAM-DEC01 ,
            :LTSOLPAR-PARAM-DEC02 ,
            :LTSOLPAR-PARAM-DEC03 ,
            :LTSOLPAR-PARAM-FLOAT01 ,
            :LTSOLPAR-PARAM-FLOAT02 ,
            :LTSOLPAR-PARAM-CHAR01 ,
            :LTSOLPAR-PARAM-CHAR02 ,
            :LTSOLPAR-PARAM-CHAR03 ,
            :LTSOLPAR-PARAM-CHAR04 ,
            :LTSOLPAR-PARAM-CHAR05 ,
            :LTSOLPAR-DTH-SOLICITACAO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.LT_SOLICITA_PARAM (COD_PRODUTO , COD_CLIENTE , COD_PROGRAMA , TIPO_SOLICITACAO, DATA_SOLICITACAO, COD_USUARIO , DATA_PREV_PROC , SIT_SOLICITACAO , TSTMP_SITUACAO , PARAM_DATE01 , PARAM_DATE02 , PARAM_DATE03 , PARAM_SMINT01 , PARAM_SMINT02 , PARAM_SMINT03 , PARAM_INTG01 , PARAM_INTG02 , PARAM_INTG03 , PARAM_DEC01 , PARAM_DEC02 , PARAM_DEC03 , PARAM_FLOAT01 , PARAM_FLOAT02 , PARAM_CHAR01 , PARAM_CHAR02 , PARAM_CHAR03 , PARAM_CHAR04 , PARAM_CHAR05 , DTH_SOLICITACAO ) VALUES ({FieldThreatment(this.LTSOLPAR_COD_PRODUTO)} , {FieldThreatment(this.LTSOLPAR_COD_CLIENTE)} , {FieldThreatment(this.LTSOLPAR_COD_PROGRAMA)} , {FieldThreatment(this.LTSOLPAR_TIPO_SOLICITACAO)} , {FieldThreatment(this.LTSOLPAR_DATA_SOLICITACAO)} , {FieldThreatment(this.LTSOLPAR_COD_USUARIO)} , {FieldThreatment(this.LTSOLPAR_DATA_PREV_PROC)} , {FieldThreatment(this.LTSOLPAR_SIT_SOLICITACAO)} , CURRENT TIMESTAMP , {FieldThreatment(this.LTSOLPAR_PARAM_DATE01)} , {FieldThreatment(this.LTSOLPAR_PARAM_DATE02)} , {FieldThreatment(this.LTSOLPAR_PARAM_DATE03)} , {FieldThreatment(this.LTSOLPAR_PARAM_SMINT01)} , {FieldThreatment(this.LTSOLPAR_PARAM_SMINT02)} , {FieldThreatment(this.LTSOLPAR_PARAM_SMINT03)} , {FieldThreatment(this.LTSOLPAR_PARAM_INTG01)} , {FieldThreatment(this.LTSOLPAR_PARAM_INTG02)} , {FieldThreatment(this.LTSOLPAR_PARAM_INTG03)} , {FieldThreatment(this.LTSOLPAR_PARAM_DEC01)} , {FieldThreatment(this.LTSOLPAR_PARAM_DEC02)} , {FieldThreatment(this.LTSOLPAR_PARAM_DEC03)} , {FieldThreatment(this.LTSOLPAR_PARAM_FLOAT01)} , {FieldThreatment(this.LTSOLPAR_PARAM_FLOAT02)} , {FieldThreatment(this.LTSOLPAR_PARAM_CHAR01)} , {FieldThreatment(this.LTSOLPAR_PARAM_CHAR02)} , {FieldThreatment(this.LTSOLPAR_PARAM_CHAR03)} , {FieldThreatment(this.LTSOLPAR_PARAM_CHAR04)} , {FieldThreatment(this.LTSOLPAR_PARAM_CHAR05)} , {FieldThreatment(this.LTSOLPAR_DTH_SOLICITACAO)})";

            return query;
        }
        public string LTSOLPAR_COD_PRODUTO { get; set; }
        public string LTSOLPAR_COD_CLIENTE { get; set; }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string LTSOLPAR_TIPO_SOLICITACAO { get; set; }
        public string LTSOLPAR_DATA_SOLICITACAO { get; set; }
        public string LTSOLPAR_COD_USUARIO { get; set; }
        public string LTSOLPAR_DATA_PREV_PROC { get; set; }
        public string LTSOLPAR_SIT_SOLICITACAO { get; set; }
        public string LTSOLPAR_PARAM_DATE01 { get; set; }
        public string LTSOLPAR_PARAM_DATE02 { get; set; }
        public string LTSOLPAR_PARAM_DATE03 { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_PARAM_SMINT02 { get; set; }
        public string LTSOLPAR_PARAM_SMINT03 { get; set; }
        public string LTSOLPAR_PARAM_INTG01 { get; set; }
        public string LTSOLPAR_PARAM_INTG02 { get; set; }
        public string LTSOLPAR_PARAM_INTG03 { get; set; }
        public string LTSOLPAR_PARAM_DEC01 { get; set; }
        public string LTSOLPAR_PARAM_DEC02 { get; set; }
        public string LTSOLPAR_PARAM_DEC03 { get; set; }
        public string LTSOLPAR_PARAM_FLOAT01 { get; set; }
        public string LTSOLPAR_PARAM_FLOAT02 { get; set; }
        public string LTSOLPAR_PARAM_CHAR01 { get; set; }
        public string LTSOLPAR_PARAM_CHAR02 { get; set; }
        public string LTSOLPAR_PARAM_CHAR03 { get; set; }
        public string LTSOLPAR_PARAM_CHAR04 { get; set; }
        public string LTSOLPAR_PARAM_CHAR05 { get; set; }
        public string LTSOLPAR_DTH_SOLICITACAO { get; set; }

        public static void Execute(R1000_00_PROCESSAR_DB_INSERT_1_Insert1 r1000_00_PROCESSAR_DB_INSERT_1_Insert1)
        {
            var ths = r1000_00_PROCESSAR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSAR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}