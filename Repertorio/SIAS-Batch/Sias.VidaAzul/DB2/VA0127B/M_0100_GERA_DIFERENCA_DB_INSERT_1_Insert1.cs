using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0127B
{
    public class M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1 : QueryBasis<M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.DIFERENCA_PARCELVA
            (NUM_CERTIFICADO,
            NUM_PARCELA ,
            NUM_PARCELA_DIF,
            COD_OPERACAO ,
            DATA_VENCIMENTO,
            PRMDEVVG ,
            PRMDEVAP ,
            PRMPAGVG ,
            PRMPAGAP ,
            PRMDIFVG ,
            PRMDIFAP ,
            VAL_MULTA ,
            SITUACAO)
            VALUES
            (:DIFERPAR-NUM-CERTIFICADO,
            :DIFERPAR-NUM-PARCELA ,
            :DIFERPAR-NUM-PARCELA-DIF,
            :DIFERPAR-COD-OPERACAO ,
            :DIFERPAR-DATA-VENCIMENTO,
            :DIFERPAR-PRMDEVVG ,
            :DIFERPAR-PRMDEVAP ,
            :DIFERPAR-PRMPAGVG ,
            :DIFERPAR-PRMPAGAP ,
            :DIFERPAR-PRMDIFVG ,
            :DIFERPAR-PRMDIFAP ,
            :DIFERPAR-VAL-MULTA ,
            :DIFERPAR-SITUACAO)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.DIFERENCA_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA , NUM_PARCELA_DIF, COD_OPERACAO , DATA_VENCIMENTO, PRMDEVVG , PRMDEVAP , PRMPAGVG , PRMPAGAP , PRMDIFVG , PRMDIFAP , VAL_MULTA , SITUACAO) VALUES ({FieldThreatment(this.DIFERPAR_NUM_CERTIFICADO)}, {FieldThreatment(this.DIFERPAR_NUM_PARCELA)} , {FieldThreatment(this.DIFERPAR_NUM_PARCELA_DIF)}, {FieldThreatment(this.DIFERPAR_COD_OPERACAO)} , {FieldThreatment(this.DIFERPAR_DATA_VENCIMENTO)}, {FieldThreatment(this.DIFERPAR_PRMDEVVG)} , {FieldThreatment(this.DIFERPAR_PRMDEVAP)} , {FieldThreatment(this.DIFERPAR_PRMPAGVG)} , {FieldThreatment(this.DIFERPAR_PRMPAGAP)} , {FieldThreatment(this.DIFERPAR_PRMDIFVG)} , {FieldThreatment(this.DIFERPAR_PRMDIFAP)} , {FieldThreatment(this.DIFERPAR_VAL_MULTA)} , {FieldThreatment(this.DIFERPAR_SITUACAO)})";

            return query;
        }
        public string DIFERPAR_NUM_CERTIFICADO { get; set; }
        public string DIFERPAR_NUM_PARCELA { get; set; }
        public string DIFERPAR_NUM_PARCELA_DIF { get; set; }
        public string DIFERPAR_COD_OPERACAO { get; set; }
        public string DIFERPAR_DATA_VENCIMENTO { get; set; }
        public string DIFERPAR_PRMDEVVG { get; set; }
        public string DIFERPAR_PRMDEVAP { get; set; }
        public string DIFERPAR_PRMPAGVG { get; set; }
        public string DIFERPAR_PRMPAGAP { get; set; }
        public string DIFERPAR_PRMDIFVG { get; set; }
        public string DIFERPAR_PRMDIFAP { get; set; }
        public string DIFERPAR_VAL_MULTA { get; set; }
        public string DIFERPAR_SITUACAO { get; set; }

        public static void Execute(M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1 m_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1)
        {
            var ths = m_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}