using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2002_CONTINUA_DB_INSERT_1_Insert1 : QueryBasis<B2002_CONTINUA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0PARCELA
            VALUES (:PARC-NUM-APOLICE
            ,:PARC-NRENDOS
            ,:PARC-NRPARCEL
            ,:PARC-DACPARC
            ,:PARC-FONTE
            ,:PARC-NRTIT
            ,:PARC-TARIFARIO-IX
            ,:PARC-DESCONTO-IX
            ,:PARC-OTNPRLIQ
            ,:PARC-OTNADFRA
            ,:PARC-OTNCUSTO
            ,:PARC-OTNIOF
            ,:PARC-OTNTOTAL
            ,:PARC-OCORHIST
            ,:PARC-QTDDOC
            ,:PARC-SITUACAO
            ,:PARC-COD-EMPRESA:PARC-EMPRESA-I
            , CURRENT TIMESTAMP
            ,:PARC-SIT-COBRANCA:PARC-COBRANCA-I
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELA VALUES ({FieldThreatment(this.PARC_NUM_APOLICE)} ,{FieldThreatment(this.PARC_NRENDOS)} ,{FieldThreatment(this.PARC_NRPARCEL)} ,{FieldThreatment(this.PARC_DACPARC)} ,{FieldThreatment(this.PARC_FONTE)} ,{FieldThreatment(this.PARC_NRTIT)} ,{FieldThreatment(this.PARC_TARIFARIO_IX)} ,{FieldThreatment(this.PARC_DESCONTO_IX)} ,{FieldThreatment(this.PARC_OTNPRLIQ)} ,{FieldThreatment(this.PARC_OTNADFRA)} ,{FieldThreatment(this.PARC_OTNCUSTO)} ,{FieldThreatment(this.PARC_OTNIOF)} ,{FieldThreatment(this.PARC_OTNTOTAL)} ,{FieldThreatment(this.PARC_OCORHIST)} ,{FieldThreatment(this.PARC_QTDDOC)} ,{FieldThreatment(this.PARC_SITUACAO)} , {FieldThreatment((this.PARC_EMPRESA_I?.ToInt() == -1 ? null : this.PARC_COD_EMPRESA))} , CURRENT TIMESTAMP , {FieldThreatment((this.PARC_COBRANCA_I?.ToInt() == -1 ? null : this.PARC_SIT_COBRANCA))} )";

            return query;
        }
        public string PARC_NUM_APOLICE { get; set; }
        public string PARC_NRENDOS { get; set; }
        public string PARC_NRPARCEL { get; set; }
        public string PARC_DACPARC { get; set; }
        public string PARC_FONTE { get; set; }
        public string PARC_NRTIT { get; set; }
        public string PARC_TARIFARIO_IX { get; set; }
        public string PARC_DESCONTO_IX { get; set; }
        public string PARC_OTNPRLIQ { get; set; }
        public string PARC_OTNADFRA { get; set; }
        public string PARC_OTNCUSTO { get; set; }
        public string PARC_OTNIOF { get; set; }
        public string PARC_OTNTOTAL { get; set; }
        public string PARC_OCORHIST { get; set; }
        public string PARC_QTDDOC { get; set; }
        public string PARC_SITUACAO { get; set; }
        public string PARC_COD_EMPRESA { get; set; }
        public string PARC_EMPRESA_I { get; set; }
        public string PARC_SIT_COBRANCA { get; set; }
        public string PARC_COBRANCA_I { get; set; }

        public static void Execute(B2002_CONTINUA_DB_INSERT_1_Insert1 b2002_CONTINUA_DB_INSERT_1_Insert1)
        {
            var ths = b2002_CONTINUA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B2002_CONTINUA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}