using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0130B
{
    public class R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 : QueryBasis<R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIS_COBER_PROPOST
            (NUM_CERTIFICADO ,
            OCORR_HISTORICO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            IMPSEGUR ,
            QUANT_VIDAS ,
            IMPSEGIND ,
            COD_OPERACAO ,
            OPCAO_COBERTURA ,
            IMP_MORNATU ,
            IMPMORACID ,
            IMPINVPERM ,
            IMPAMDS ,
            IMPDH ,
            IMPDIT ,
            VLPREMIO ,
            PRMVG ,
            PRMAP ,
            QTDE_TIT_CAPITALIZ,
            VAL_TIT_CAPITALIZ ,
            VAL_CUSTO_CAPITALI,
            IMPSEGCDG ,
            VLCUSTCDG ,
            COD_USUARIO ,
            TIMESTAMP ,
            IMPSEGAUXF ,
            VLCUSTAUXF ,
            PRMDIT ,
            QTMDIT)
            VALUES ( :HISCOBPR-NUM-CERTIFICADO
            ,:HISCOBPR-OCORR-HISTORICO
            ,:HISCOBPR-DATA-INIVIGENCIA
            ,:HISCOBPR-DATA-TERVIGENCIA
            ,:HISCOBPR-IMPSEGUR
            ,:HISCOBPR-QUANT-VIDAS
            ,:HISCOBPR-IMPSEGIND
            ,:HISCOBPR-COD-OPERACAO
            ,:HISCOBPR-OPCAO-COBERTURA
            ,:HISCOBPR-IMP-MORNATU
            ,:HISCOBPR-IMPMORACID
            ,:HISCOBPR-IMPINVPERM
            ,:HISCOBPR-IMPAMDS
            ,:HISCOBPR-IMPDH
            ,:HISCOBPR-IMPDIT
            ,:HISCOBPR-VLPREMIO
            ,:HISCOBPR-PRMVG
            ,:HISCOBPR-PRMAP
            ,:HISCOBPR-QTDE-TIT-CAPITALIZ
            ,:HISCOBPR-VAL-TIT-CAPITALIZ
            ,:HISCOBPR-VAL-CUSTO-CAPITALI
            ,:HISCOBPR-IMPSEGCDG
            ,:HISCOBPR-VLCUSTCDG
            , 'VE0130B'
            , CURRENT TIMESTAMP
            ,:HISCOBPR-IMPSEGAUXF:VIND-IMPSEGAUXF
            ,:HISCOBPR-VLCUSTAUXF:VIND-VLCUSTAUXF
            ,:HISCOBPR-PRMDIT :VIND-PRMDIT
            ,:HISCOBPR-QTMDIT :VIND-QTMDIT )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES ( {FieldThreatment(this.HISCOBPR_NUM_CERTIFICADO)} ,{FieldThreatment(this.HISCOBPR_OCORR_HISTORICO)} ,{FieldThreatment(this.HISCOBPR_DATA_INIVIGENCIA)} ,{FieldThreatment(this.HISCOBPR_DATA_TERVIGENCIA)} ,{FieldThreatment(this.HISCOBPR_IMPSEGUR)} ,{FieldThreatment(this.HISCOBPR_QUANT_VIDAS)} ,{FieldThreatment(this.HISCOBPR_IMPSEGIND)} ,{FieldThreatment(this.HISCOBPR_COD_OPERACAO)} ,{FieldThreatment(this.HISCOBPR_OPCAO_COBERTURA)} ,{FieldThreatment(this.HISCOBPR_IMP_MORNATU)} ,{FieldThreatment(this.HISCOBPR_IMPMORACID)} ,{FieldThreatment(this.HISCOBPR_IMPINVPERM)} ,{FieldThreatment(this.HISCOBPR_IMPAMDS)} ,{FieldThreatment(this.HISCOBPR_IMPDH)} ,{FieldThreatment(this.HISCOBPR_IMPDIT)} ,{FieldThreatment(this.HISCOBPR_VLPREMIO)} ,{FieldThreatment(this.HISCOBPR_PRMVG)} ,{FieldThreatment(this.HISCOBPR_PRMAP)} ,{FieldThreatment(this.HISCOBPR_QTDE_TIT_CAPITALIZ)} ,{FieldThreatment(this.HISCOBPR_VAL_TIT_CAPITALIZ)} ,{FieldThreatment(this.HISCOBPR_VAL_CUSTO_CAPITALI)} ,{FieldThreatment(this.HISCOBPR_IMPSEGCDG)} ,{FieldThreatment(this.HISCOBPR_VLCUSTCDG)} , 'VE0130B' , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_IMPSEGAUXF?.ToInt() == -1 ? null : this.HISCOBPR_IMPSEGAUXF))} , {FieldThreatment((this.VIND_VLCUSTAUXF?.ToInt() == -1 ? null : this.HISCOBPR_VLCUSTAUXF))} , {FieldThreatment((this.VIND_PRMDIT?.ToInt() == -1 ? null : this.HISCOBPR_PRMDIT))} , {FieldThreatment((this.VIND_QTMDIT?.ToInt() == -1 ? null : this.HISCOBPR_QTMDIT))} )";

            return query;
        }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_DATA_TERVIGENCIA { get; set; }
        public string HISCOBPR_IMPSEGUR { get; set; }
        public string HISCOBPR_QUANT_VIDAS { get; set; }
        public string HISCOBPR_IMPSEGIND { get; set; }
        public string HISCOBPR_COD_OPERACAO { get; set; }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPAMDS { get; set; }
        public string HISCOBPR_IMPDH { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_CUSTO_CAPITALI { get; set; }
        public string HISCOBPR_IMPSEGCDG { get; set; }
        public string HISCOBPR_VLCUSTCDG { get; set; }
        public string HISCOBPR_IMPSEGAUXF { get; set; }
        public string VIND_IMPSEGAUXF { get; set; }
        public string HISCOBPR_VLCUSTAUXF { get; set; }
        public string VIND_VLCUSTAUXF { get; set; }
        public string HISCOBPR_PRMDIT { get; set; }
        public string VIND_PRMDIT { get; set; }
        public string HISCOBPR_QTMDIT { get; set; }
        public string VIND_QTMDIT { get; set; }

        public static void Execute(R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 r8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1)
        {
            var ths = r8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}