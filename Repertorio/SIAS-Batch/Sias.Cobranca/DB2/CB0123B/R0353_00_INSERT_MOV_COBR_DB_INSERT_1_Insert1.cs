using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1 : QueryBasis<R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.MOVIMENTO_COBRANCA
            ( COD_EMPRESA
            , COD_MOVIMENTO
            , COD_BANCO
            , COD_AGENCIA
            , NUM_AVISO
            , NUM_FITA
            , DATA_MOVIMENTO
            , DATA_QUITACAO
            , NUM_TITULO
            , NUM_APOLICE
            , NUM_ENDOSSO
            , NUM_PARCELA
            , VAL_TITULO
            , VAL_IOCC
            , VAL_CREDITO
            , SIT_REGISTRO
            , TIMESTAMP
            , NOME_SEGURADO
            , TIPO_MOVIMENTO
            , NUM_NOSSO_TITULO
            )
            VALUES
            ( :MOVIMCOB-COD-EMPRESA
            , :MOVIMCOB-COD-MOVIMENTO
            , :MOVIMCOB-COD-BANCO
            , :MOVIMCOB-COD-AGENCIA
            , :MOVIMCOB-NUM-AVISO
            , :MOVIMCOB-NUM-FITA
            , :MOVIMCOB-DATA-MOVIMENTO
            , :MOVIMCOB-DATA-QUITACAO
            , :MOVIMCOB-NUM-TITULO
            , :MOVIMCOB-NUM-APOLICE
            , :MOVIMCOB-NUM-ENDOSSO
            , :MOVIMCOB-NUM-PARCELA
            , :MOVIMCOB-VAL-TITULO
            , :MOVIMCOB-VAL-IOCC
            , :MOVIMCOB-VAL-CREDITO
            , :MOVIMCOB-SIT-REGISTRO
            , CURRENT TIMESTAMP
            , :MOVIMCOB-NOME-SEGURADO
            , :MOVIMCOB-TIPO-MOVIMENTO
            , :MOVIMCOB-NUM-NOSSO-TITULO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMENTO_COBRANCA ( COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_IOCC , VAL_CREDITO , SIT_REGISTRO , TIMESTAMP , NOME_SEGURADO , TIPO_MOVIMENTO , NUM_NOSSO_TITULO ) VALUES ( {FieldThreatment(this.MOVIMCOB_COD_EMPRESA)} , {FieldThreatment(this.MOVIMCOB_COD_MOVIMENTO)} , {FieldThreatment(this.MOVIMCOB_COD_BANCO)} , {FieldThreatment(this.MOVIMCOB_COD_AGENCIA)} , {FieldThreatment(this.MOVIMCOB_NUM_AVISO)} , {FieldThreatment(this.MOVIMCOB_NUM_FITA)} , {FieldThreatment(this.MOVIMCOB_DATA_MOVIMENTO)} , {FieldThreatment(this.MOVIMCOB_DATA_QUITACAO)} , {FieldThreatment(this.MOVIMCOB_NUM_TITULO)} , {FieldThreatment(this.MOVIMCOB_NUM_APOLICE)} , {FieldThreatment(this.MOVIMCOB_NUM_ENDOSSO)} , {FieldThreatment(this.MOVIMCOB_NUM_PARCELA)} , {FieldThreatment(this.MOVIMCOB_VAL_TITULO)} , {FieldThreatment(this.MOVIMCOB_VAL_IOCC)} , {FieldThreatment(this.MOVIMCOB_VAL_CREDITO)} , {FieldThreatment(this.MOVIMCOB_SIT_REGISTRO)} , CURRENT TIMESTAMP , {FieldThreatment(this.MOVIMCOB_NOME_SEGURADO)} , {FieldThreatment(this.MOVIMCOB_TIPO_MOVIMENTO)} , {FieldThreatment(this.MOVIMCOB_NUM_NOSSO_TITULO)} )";

            return query;
        }
        public string MOVIMCOB_COD_EMPRESA { get; set; }
        public string MOVIMCOB_COD_MOVIMENTO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_NUM_FITA { get; set; }
        public string MOVIMCOB_DATA_MOVIMENTO { get; set; }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string MOVIMCOB_VAL_IOCC { get; set; }
        public string MOVIMCOB_VAL_CREDITO { get; set; }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NOME_SEGURADO { get; set; }
        public string MOVIMCOB_TIPO_MOVIMENTO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }

        public static void Execute(R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1 r0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1)
        {
            var ths = r0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}