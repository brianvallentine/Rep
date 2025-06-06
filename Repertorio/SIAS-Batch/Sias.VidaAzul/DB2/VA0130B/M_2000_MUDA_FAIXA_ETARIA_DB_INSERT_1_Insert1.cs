using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 : QueryBasis<M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIS_COBER_PROPOST
            (NUM_CERTIFICADO,
            OCORR_HISTORICO,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            IMPSEGUR,
            QUANT_VIDAS,
            IMPSEGIND,
            COD_OPERACAO,
            OPCAO_COBERTURA,
            IMP_MORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP,
            QTDE_TIT_CAPITALIZ,
            VAL_TIT_CAPITALIZ,
            VAL_CUSTO_CAPITALI,
            IMPSEGCDG,
            VLCUSTCDG,
            COD_USUARIO,
            TIMESTAMP,
            IMPSEGAUXF,
            VLCUSTAUXF,
            PRMDIT,
            QTMDIT)
            VALUES (
            :PROPVA-NRCERTIF,
            :PROPVA-OCORHIST,
            DATE(:COBERP-DTINIVIG) + 1 DAY ,
            '9999-12-31' ,
            :COBERP-IMPSEGUR-ANT,
            :COBERP-QUANT-VIDAS-ANT,
            :COBERP-IMPSEGIND-ANT,
            :COD-OPERACAO,
            :COBERP-OPCAO-COBER-ANT,
            :COBERP-IMPMORNATU-ANT,
            :COBERP-IMPMORACID-ANT,
            :COBERP-IMPINVPERM-ANT,
            :COBERP-IMPAMDS-ANT,
            :COBERP-IMPDH-ANT,
            :COBERP-IMPDIT-ANT,
            :COBERP-VLPREMIO-ATU,
            :COBERP-PRMVG-ATU,
            :COBERP-PRMAP-ATU,
            :COBERP-QTTITCAP,
            :COBERP-VLTITCAP,
            :COBERP-VLCUSTCAP,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            'VA0130B' ,
            CURRENT TIMESTAMP,
            :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I,
            :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I,
            :COBERP-PRMDIT-ATU:COBERP-PRMDIT-I,
            :COBERP-QTDIT:COBERP-QTDIT-I)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ, VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, COD_USUARIO, TIMESTAMP, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTMDIT) VALUES ( {FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.PROPVA_OCORHIST)}, DATE({FieldThreatment(this.COBERP_DTINIVIG)}) + 1 DAY , '9999-12-31' , {FieldThreatment(this.COBERP_IMPSEGUR_ANT)}, {FieldThreatment(this.COBERP_QUANT_VIDAS_ANT)}, {FieldThreatment(this.COBERP_IMPSEGIND_ANT)}, {FieldThreatment(this.COD_OPERACAO)}, {FieldThreatment(this.COBERP_OPCAO_COBER_ANT)}, {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, {FieldThreatment(this.COBERP_IMPMORACID_ANT)}, {FieldThreatment(this.COBERP_IMPINVPERM_ANT)}, {FieldThreatment(this.COBERP_IMPAMDS_ANT)}, {FieldThreatment(this.COBERP_IMPDH_ANT)}, {FieldThreatment(this.COBERP_IMPDIT_ANT)}, {FieldThreatment(this.COBERP_VLPREMIO_ATU)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.COBERP_PRMAP_ATU)}, {FieldThreatment(this.COBERP_QTTITCAP)}, {FieldThreatment(this.COBERP_VLTITCAP)}, {FieldThreatment(this.COBERP_VLCUSTCAP)}, {FieldThreatment(this.COBERP_IMPSEGCDG)}, {FieldThreatment(this.COBERP_VLCUSTCDG)}, 'VA0130B' , CURRENT TIMESTAMP,  {FieldThreatment((this.COBERP_IMPSEGAUXF_I?.ToInt() == -1 ? null : this.COBERP_IMPSEGAUXF))},  {FieldThreatment((this.COBERP_VLCUSTAUXF_I?.ToInt() == -1 ? null : this.COBERP_VLCUSTAUXF))},  {FieldThreatment((this.COBERP_PRMDIT_I?.ToInt() == -1 ? null : this.COBERP_PRMDIT_ATU))},  {FieldThreatment((this.COBERP_QTDIT_I?.ToInt() == -1 ? null : this.COBERP_QTDIT))})";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string COBERP_DTINIVIG { get; set; }
        public string COBERP_IMPSEGUR_ANT { get; set; }
        public string COBERP_QUANT_VIDAS_ANT { get; set; }
        public string COBERP_IMPSEGIND_ANT { get; set; }
        public string COD_OPERACAO { get; set; }
        public string COBERP_OPCAO_COBER_ANT { get; set; }
        public string COBERP_IMPMORNATU_ANT { get; set; }
        public string COBERP_IMPMORACID_ANT { get; set; }
        public string COBERP_IMPINVPERM_ANT { get; set; }
        public string COBERP_IMPAMDS_ANT { get; set; }
        public string COBERP_IMPDH_ANT { get; set; }
        public string COBERP_IMPDIT_ANT { get; set; }
        public string COBERP_VLPREMIO_ATU { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string COBERP_PRMAP_ATU { get; set; }
        public string COBERP_QTTITCAP { get; set; }
        public string COBERP_VLTITCAP { get; set; }
        public string COBERP_VLCUSTCAP { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IMPSEGAUXF_I { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_VLCUSTAUXF_I { get; set; }
        public string COBERP_PRMDIT_ATU { get; set; }
        public string COBERP_PRMDIT_I { get; set; }
        public string COBERP_QTDIT { get; set; }
        public string COBERP_QTDIT_I { get; set; }

        public static void Execute(M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 m_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1)
        {
            var ths = m_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}